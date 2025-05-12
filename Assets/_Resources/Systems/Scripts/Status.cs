using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Status : MonoBehaviour
{
    public Rigidbody rb;
    
    [Header("Damage")]
    public float Damage = 10f;

    [Header("HP")]
    [SerializeField] private Image hpBar;
    public float hpCurrent;
    public float hpMax = 100f;

    [Header("MP")]
    [SerializeField] private Image mpBar;
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
    public virtual void Update()
    {
        _Recover_HP();
        _Recovery_MP();
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
    private void _Recover_HP()
    {
        if(hpCurrent < hpMax)
        {
            hpBar.fillAmount = (hpCurrent / hpMax) / 2.5f;
            hpCurrent += (hpMax / 90) * Time.deltaTime;
            if (hpCurrent > hpMax) hpCurrent = hpMax;
        }
    }
    private void _Recovery_MP()
    {
        if (mpCurrent < mpMax)
        {
            mpBar.fillAmount = (mpCurrent / mpMax) / 2.5f;
            mpCurrent += (mpMax / 5) * Time.deltaTime;
            if (mpCurrent > mpMax) mpCurrent = mpMax;
        }
    }
}
