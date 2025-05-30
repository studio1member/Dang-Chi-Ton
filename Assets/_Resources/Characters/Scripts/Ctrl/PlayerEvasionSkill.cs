using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvasionSkill : MonoBehaviour
{
    private Player player;
    private Vector3 posTarget;
    private float timer;
    private void Awake()
    {
        if (this.player == null) player = GetComponent<Player>();
    }
    private void Update()
    {
        if (this.timer > 0) this.timer -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Q)) _Evasion_Skill_Activate();
    }
    private void FixedUpdate()
    {
        if (this.timer > 0) _Evasion_Skill();
    }
    public void _Evasion_Skill_Activate()
    {
        if (this.player.playerStatus.mpCurrent <= 25f) return;
        this.player.playerStatus.mpCurrent -= 25f;
        this.player.rb.velocity = Vector3.zero;
        this.timer = 0.5f;
    }
    private void _Evasion_Skill()
    {
        Vector3 pos = transform.forward;
        this.player.rb.AddForce(20000f * pos * Time.fixedDeltaTime,ForceMode.Force);
    }
}
