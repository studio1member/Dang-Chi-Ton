using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    private Player player;
    [SerializeField] private LayerMask layerGround;
    [SerializeField] private float directionCheck = 1f;
    private float ver, hor;
    private Transform pointCheckGround;

    private void Awake()
    {
        foreach (Transform i in transform) if (i.name == "Point Check Ground") pointCheckGround = i;
    }
    private void Start()
    {
        player = Player.instance.GetComponent<Player>();
    }
    private void Update()
    {
        _Ctrl();
    }
    private void FixedUpdate()
    {
        
    }
    private void _Ctrl()
    {
        ver = Input.GetAxis("Vertical");
        hor = Input.GetAxis("Horizontal");

        player.checkJump = Physics.Raycast(pointCheckGround.position, Vector3.down, directionCheck, layerGround);
    }
}
