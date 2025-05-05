using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Player : MonoBehaviour
{
    public static Player instance;
    public Status status;

    [Header("Component")]
    public Rigidbody rb;
    public Animator anim;
    public LayerMask Enemy;

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
    public float moveSpeedBasic = 7f;
    public float moveSpeeMax = 14;
    public float moveSpeed;
    public float air = 0.5f;
    public float drag = 5f;

    [Header("Jump")]
    public LayerMask layerGround;
    public float jumpForce = 6f;

    [Header("Animation")]
    public string moveAnim = "Move";
    public string jumpAnim = "Jump";
    public string attackAnim = "Attack01";

    private void Awake()
    {
        moveSpeed = moveSpeedBasic;
        instance = this;
        rb = GetComponent<Rigidbody>();
        foreach (Transform t in transform) if (t.name == "Model") anim = t.GetComponent<Animator>();
        status = GetComponent<Status>();
        _Awake_Camera();
    }
    private void _Awake_Camera()
    {
        foreach (Transform child in GetComponentsInChildren<Transform>())
        {
            if (child.name == "Camera Main") cameraMain = child;
            if (child.name == "Look") look = child;
            if (child.name == "Camera01") camera01 = child;
            if (child.name == "Camera02") camera02 = child;
            if (child.name == "Camera03") camera03 = child;
            if (child.name == "Main Camera"){
                mainCamera = child;
                break;
            }
        }
    }
}
