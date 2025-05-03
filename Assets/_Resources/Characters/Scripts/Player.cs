using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Player : MonoBehaviour
{
    public static Player instance;

    [Header("Camera")]
    public Transform cameraMain;
    public Transform camera01;
    public Transform camera02;
    public Transform camera03;
    public Transform mainCamera;

    [Header("Move")]
    public bool checkJump;
    public float moveSpeed;
    public float air;

    private void Awake()
    {
        instance = this;
        _Awake_Camera();
    }
    private void _Awake_Camera()
    {
        foreach (Transform child in GetComponentsInChildren<Transform>())
        {
            if (child.name == "Camera Main") cameraMain = child;
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
