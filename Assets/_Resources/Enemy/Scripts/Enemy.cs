using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy")]
    public Rigidbody rb;
    public Animator anim;

    [Header("Check Player")]
    public float speed = 15f;
    public Transform player;

    [Header("Attack")]
    public bool notAttack;
}
