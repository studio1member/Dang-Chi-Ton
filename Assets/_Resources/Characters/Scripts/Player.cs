using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Player : MonoBehaviour
{
    [Header("Component")]
    public Transform playerParent;
    public Rigidbody rb;
    public Animator anim;
    public LayerMask Enemy;

    public GameObject playerScripts;
    public PlayerCtrl playerCtrl;
    public PlayerCamera playerCamera;
    public PlayerStatus playerStatus;
    public AttackSystem attacksSystem;

    [Header("Camera")]
    public bool zoom;
    public Transform cameraMain;
    public Transform look;
    public Transform camera01;
    public Transform camera02;
    public Transform camera03;
    public Transform mainCamera;

    [Header("Sensitivity")]
    public float sensitivity;

    [Header("Move")]
    public bool checkGround;
    public bool checkWall;
    public float moveSpeedBasic = 5f;
    public float moveSpeeMax = 10;
    public float moveSpeed;
    public float air = 0.3f;
    public float drag = 5f;

    [Header("Jump")]
    public LayerMask layerGround;
    public int jumpContinuously = 10;
    public float jumpForce = 6f;

    [Header("Animation")]
    public string moveAnim = "Move";
    public string jumpAnim = "Jump";
    public string attackAnim = "Attack01";

    private void Awake()
    {
        moveSpeed = moveSpeedBasic;
    }
}
