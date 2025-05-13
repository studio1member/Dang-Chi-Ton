using System.Collections;
using System.Collections.Generic;
using Photon.Realtime;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyCtrl : MonoBehaviour
{
    private Enemy enemy;
    [SerializeField] LayerMask player;
    [SerializeField] Transform pointAttack;

    private void Awake()
    {
        enemy = GetComponent<Enemy>();
    }

    private void Update()
    {
        _Enemy_Follow();
    }
    private void _Enemy_Follow()
    {
        if (enemy.player)
        {
            enemy.anim.SetBool("Run", true);
            if (Vector3.Distance(transform.position, enemy.player.position) > 1.5f && enemy.notAttack)
            {
                _Enemy_Look();
                Vector3 playerPos = new Vector3(enemy.player.position.x, enemy.rb.velocity.y, enemy.player.position.z);
                Vector3 pos = Vector3.MoveTowards(enemy.rb.position, playerPos, enemy.speed * Time.deltaTime);
                enemy.rb.MovePosition(pos);
                if (Vector3.Distance(transform.position, enemy.player.position) > 20f) enemy.player = null;
            }
            else
            {
                enemy.anim.SetBool("Run", false);
                if (enemy.notAttack) StartCoroutine(_Enemy_Attack());
            }
        }
        else
        {
            enemy.anim.SetBool("Run", false);
        }
    }
    private void _Enemy_Look()
    {
        Vector3 direction = enemy.player.position - transform.position;
        direction.y = 0; // giữ nguyên chiều cao
        if (direction != Vector3.zero)
            transform.rotation = Quaternion.LookRotation(direction);
    }
    private IEnumerator _Enemy_Attack()
    {
        enemy.notAttack = false;
        enemy.anim.SetTrigger("Attack1");
        StartCoroutine(_DelayAttack());
        yield return new WaitForSeconds(0.5f);
        enemy.notAttack = true;
    }
    private IEnumerator _DelayAttack()
    {
        yield return new WaitForSeconds(0.25f);
        RaycastHit[] hits = Physics.SphereCastAll(pointAttack.position, 1.5f, transform.forward, 0, player);
        foreach (RaycastHit hit in hits)
        {
            hit.collider.GetComponent<Status>()._Dame_Receiver(15, false, transform, 0);
        }
    }
    private void OnDrawGizmos()
    {
        // Màu gizmo
        Gizmos.color = Color.cyan;

        // Vị trí bắt đầu
        Vector3 origin = pointAttack.position;

        // Vẽ sphere ở vị trí bắt đầu
        Gizmos.DrawWireSphere(origin, 1.5f);

        // Vị trí kết thúc
        Vector3 end = origin + pointAttack.forward.normalized * 0;

        // Vẽ sphere ở vị trí kết thúc
        Gizmos.DrawWireSphere(end, 1.5f);

        // Vẽ đường nối từ đầu đến cuối
        Gizmos.DrawLine(origin, end);
    }
}
