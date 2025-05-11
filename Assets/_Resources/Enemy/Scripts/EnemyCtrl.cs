using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : MonoBehaviour
{
    private Enemy enemy;

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
        if (!enemy.player) return;
        transform.position -= enemy.player.position * Time.deltaTime;
    }
}
