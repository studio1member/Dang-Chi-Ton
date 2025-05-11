using System.Collections;
using System.Collections.Generic;
using Photon.Realtime;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    [SerializeField] private Player player;
    [Header("Check Ground")]
    [SerializeField] private float directionCheck = 0.3f;
    [SerializeField] private GameObject jumpEffect;

    private float ver, hor;
    private void Update()
    {
        _Ctrl();
        _Limit_Speed();
    }
    private void FixedUpdate()
    {
        _Move();
        _Rotation();
    }
    private void _Ctrl()
    {
        ver = Input.GetAxis("Vertical");
        hor = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && player.checkGround || Input.GetKeyDown(KeyCode.Space) && player.checkWall || Input.GetKeyDown(KeyCode.Space) && player.jumpContinuously > 1) _Jump();
        _Speed_Up();

        player.checkGround = Physics.Raycast(transform.position, Vector3.down, directionCheck + 1f, player.layerGround);
        if (player.checkGround) player.jumpContinuously = 10;
        float jumpf = player.rb.velocity.y;
        player.anim.SetFloat(player.jumpAnim, jumpf);
    }
    private void _Move()
    {
        Vector3 move = player.cameraMain.forward * ver + player.cameraMain.right * hor;
        if (player.checkGround)
        {
            player.rb.drag = player.drag;
            player.rb.AddForce(move * player.moveSpeed * 10, ForceMode.Force);
            _Animation();
        } 
        else
        {
            player.rb.drag = 0f;
            player.rb.AddForce(move * player.moveSpeed * player.air, ForceMode.Force);
            _Animation();
        }
    }
    private void _Animation()
    {
        player.anim.SetFloat(player.moveAnim, player.rb.velocity.magnitude);
    }
    private void _Limit_Speed()
    {
        Vector3 checkVeclocity = new Vector3(player.rb.velocity.x, 0, player.rb.velocity.z);
        if (checkVeclocity.magnitude > player.moveSpeed)
        {
            Vector3 limitSpeed = checkVeclocity.normalized * player.moveSpeed;
            player.rb.velocity = new Vector3(limitSpeed.x, player.rb.velocity.y, limitSpeed.z);
        }
    }
    private void _Speed_Up()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)) player.moveSpeed = player.moveSpeeMax;
        if (Input.GetKeyUp(KeyCode.LeftShift)) player.moveSpeed = player.moveSpeedBasic;
    }
    private void _Rotation()
    {
        Vector3 rotation = player.cameraMain.forward * ver + player.cameraMain.right * hor;
        rotation.y = 0;
        if (rotation.magnitude > 0.1f)
        {
            player.playerParent.forward = rotation.normalized;
        }
    }
    private void _Jump()
    {
        player.jumpContinuously -= 1;
        Vector3 point = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        GameObject effect = Instantiate(jumpEffect, point, Quaternion.identity);
        effect.SetActive(true);
        Destroy(effect, 1f);
        player.rb.velocity = new Vector3(player.rb.velocity.x, 0, player.rb.velocity.z);
        player.rb.AddForce(transform.up * player.jumpForce, ForceMode.Impulse);
    }
}
