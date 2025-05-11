using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCheckPlayer : MonoBehaviour
{
    [SerializeField] private float radiusCheck;
    [SerializeField] private LayerMask playerMask;
    private Enemy enemy;
    private void Awake()
    {
        enemy = GetComponent<Enemy>();
    }
    private void Update()
    {
        _Check_Player();
    }
    private void _Check_Player()
    {
        Collider[] player = Physics.OverlapSphere(transform.position, radiusCheck, playerMask);
        if (player != null) foreach (Collider i in player) if (i.GetComponent<Status>()) enemy.player = i.transform;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radiusCheck);
    }
}
