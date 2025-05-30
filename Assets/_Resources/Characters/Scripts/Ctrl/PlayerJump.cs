using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private Player player;
    private float timerDelayAnimJump;
    private void Awake()
    {
        if (player == null) player = GetComponent<Player>();
    }
    private void Update()
    {
        _Input();
    }
    private void _Input()
    {
        if (Input.GetKeyDown(KeyCode.Space)) _Jump_Activate();

        if (timerDelayAnimJump > 0) timerDelayAnimJump -= Time.deltaTime;
        if (player.checkGround)
        {
            if (this.timerDelayAnimJump <= 0) this.player.anim.SetBool(player.jumpAnim, false);
            this.player.playerStatus.jumpContinuously = 5;
        }
    }
    public void _Jump_Activate()
    {
        if (this.player.playerStatus.mpCurrent > 25) {
            if (this.player.checkGround || this.player.checkWall || this.player.playerStatus.jumpContinuously > 1) _Jump(); }
    }
    private void _Jump()
    {
        this.player.playerStatus.mpCurrent -= 25f;
        timerDelayAnimJump = 0.5f;
        this.player.playerStatus.jumpContinuously -= 1;
        this.player.rb.velocity = new Vector3(player.rb.velocity.x, 0, player.rb.velocity.z);
        this.player.rb.AddForce(transform.up * player.playerStatus.jumpForce, ForceMode.Impulse);
        this.player.anim.SetBool(player.jumpAnim, true);
        //effect
        this.player.playerPhoton._Jump_Effects();
    }
}
