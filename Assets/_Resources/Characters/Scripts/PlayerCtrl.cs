using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    private Player player;
    [Header("Check Ground")]
    [SerializeField] private float directionCheck = 0.3f;

    private float ver, hor;
    private void Start()
    {
        player = Player.instance.GetComponent<Player>();
    }
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

        if (Input.GetKeyDown(KeyCode.Space) && player.checkGround || Input.GetKeyDown(KeyCode.Space) && player.checkWall) _Jump();
        _Speed_Up();

        player.checkGround = Physics.Raycast(transform.position, Vector3.down, directionCheck + 1f, player.layerGround);

        if (player.checkGround) player.anim.SetBool("Jump", false);
        else player.anim.SetBool("Jump", true);
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
        player.anim.SetFloat("Speed", player.rb.velocity.magnitude);
        player.anim.SetFloat("Jumpf", player.rb.velocity.y);
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
            transform.forward = rotation.normalized;
        }
    }
    private void _Jump()
    {
        player.rb.velocity = new Vector3(player.rb.velocity.x, 0, player.rb.velocity.z);
        player.rb.AddForce(transform.up * player.jumpForce, ForceMode.Impulse);
    }
}
