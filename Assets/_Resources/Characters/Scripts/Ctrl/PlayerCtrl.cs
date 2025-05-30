using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    [SerializeField] private Player player;
    [Header("Check Ground")]
    private float directionCheck = 0.3f;
    [SerializeField] private FloatingJoystick joystick;

    public float ver, hor;
    private void Start()
    {
        this.player.playerStatus.moveSpeed = this.player.playerStatus.moveSpeedBasic;
    }
    private void Update()
    {
        _Ctrl();
        _Limit_Speed();
    }
    private void FixedUpdate()
    {
        if (player.isGet) return;
        _Move();
        _Rotation();
    }
    private void _Ctrl()
    {
        ver = this.joystick.Vertical;
        hor = this.joystick.Horizontal;
        ver = Input.GetAxis("Vertical");
        hor = Input.GetAxis("Horizontal");

        if (player.isGet) return;

        _Speed_Up();

        player.checkGround = Physics.Raycast(transform.position, Vector3.down, directionCheck + 1f, player.layerGround);
    }
    private void _Move()
    {
        Vector3 move = player.cameraMain.forward * ver + player.cameraMain.right * hor;
        if (player.checkGround)
        {
            player.rb.drag = player.drag;
            player.rb.AddForce(move * player.playerStatus.moveSpeed * 10, ForceMode.Force);
            _Animation();
        } 
        else
        {
            player.rb.drag = 0f;
            player.rb.AddForce(move * player.playerStatus.moveSpeed * player.air, ForceMode.Force);
            _Animation();
        }
    }
    private void _Animation()
    {
        this.player.anim.SetFloat(player.moveAnim, player.rb.velocity.magnitude);
    }
    private void _Limit_Speed()
    {
        Vector3 checkVeclocity = new Vector3(player.rb.velocity.x, 0, player.rb.velocity.z);
        if (checkVeclocity.magnitude > player.playerStatus.moveSpeed)
        {
            Vector3 limitSpeed = checkVeclocity.normalized * player.playerStatus.moveSpeed;
            player.rb.velocity = new Vector3(limitSpeed.x, player.rb.velocity.y, limitSpeed.z);
        }
    }
    private void _Speed_Up()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)) player.playerStatus.moveSpeed = player.playerStatus.moveSpeeMax;
        if (Input.GetKeyUp(KeyCode.LeftShift)) player.playerStatus.moveSpeed = player.playerStatus.moveSpeedBasic;
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
}
