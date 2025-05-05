using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayer : MonoBehaviour
{
    [SerializeField] private float radiusCheck;
    [SerializeField] private LayerMask playerMask;
    public Transform player;
    private void Update()
    {
        _Check_Player();
    }
    private void _Check_Player()
    {
        Collider[] player = Physics.OverlapSphere(transform.position, radiusCheck, playerMask);
        if (player != null) foreach (Collider i in player) if (i.GetComponent<Status>()) this.player = i.transform;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radiusCheck);
    }
}
