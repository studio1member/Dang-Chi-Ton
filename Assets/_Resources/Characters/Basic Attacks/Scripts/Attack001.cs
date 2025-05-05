using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack001 : AttackSystem
{
    [SerializeField] private float radius, distance, knockBack;
    [SerializeField] private Vector3 direction = Vector3.forward;
    public override void _Mouse_Left()
    {
        player.anim.SetTrigger(player.attackAnim);
        RaycastHit[] hits = Physics.SphereCastAll(transform.position, radius, direction, distance, player.Enemy);
        foreach (RaycastHit hit in hits)
        {
            hit.collider.GetComponent<Status>()._Dame_Receiver(player.status.Damage, true, transform, knockBack);
        }
        base._Mouse_Left();
    }
    void OnDrawGizmosSelected()
    {
        // Màu gizmo
        Gizmos.color = Color.cyan;

        // Vị trí bắt đầu
        Vector3 origin = transform.position;

        // Vẽ sphere ở vị trí bắt đầu
        Gizmos.DrawWireSphere(origin, radius);

        // Vị trí kết thúc
        Vector3 end = origin + direction.normalized * distance;

        // Vẽ sphere ở vị trí kết thúc
        Gizmos.DrawWireSphere(end, radius);

        // Vẽ đường nối từ đầu đến cuối
        Gizmos.DrawLine(origin, end);
    }
}
