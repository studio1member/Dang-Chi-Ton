using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : Status
{
    public GameObject playerScript;

    [Header("Move")]
    public float moveSpeedBasic = 5f;
    public float moveSpeeMax = 10;
    public float moveSpeed;

    [Header("Jump")]
    public int jumpContinuously = 5;
    public float jumpForce = 6f;
}
