using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    public Rigidbody rb;
    [Header("Damage")]
    public float Damage = 10f;

    [Header("HP")]
    public float hpCurrent;
    public float hpMax = 100f;

    [Header("MP")]
    public float mpCurrent;
    public float mpMax = 100f;

    [Header("Armor")]
    public float armor = 5f;

    [Header("Knock Back")]
    public bool knockBack = true;

    [Header("Resistance Effect")]
    public float resistanceEffect = 0f;
    public virtual void Awake()
    {
        rb = GetComponent<Rigidbody>();
        hpCurrent = hpMax;
        mpCurrent = mpMax;
    }
    public virtual void _Dame_Receiver(float damage, bool knockBack, Transform damageSourcePosition, float knockBackForce)
    {
        float dam = damage - armor;
        if (dam < 1) dam = 1f;
        this.hpCurrent -= dam;
        if (knockBack && this.knockBack)
        {
            Vector3 knockBackDirection = transform.position - damageSourcePosition.position;
            rb.AddForce(knockBackDirection * knockBackForce, ForceMode.Impulse);
        }
    }
}
