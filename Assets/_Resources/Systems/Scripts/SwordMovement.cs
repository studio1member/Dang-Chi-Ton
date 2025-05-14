using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordMovement : MonoBehaviour
{
    public Player player;
    public Rigidbody rb;
    public float speed = 9;
    private RaycastHit hit;
    [SerializeField] float forceUp;
    [SerializeField] LayerMask groundMask;
    private void Start()
    {
        rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
    }
    private void Update()
    {
        if (player != null) Move();
    }
    private void Move()
    {
        transform.LookAt(player.lookSword);
        Vector3 move = player.playerCtrl.ver * transform.forward + player.playerCtrl.hor * transform.right;
        rb.AddForce(move.normalized * 1000f * speed * Time.deltaTime, ForceMode.Force);
        CheckDistanceGround();
    }
    private void CheckDistanceGround()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 10f, groundMask))
        {
            float distanceToGround = hit.distance;
            if (distanceToGround < 2f)
            {
                Vector3 newPosition = transform.position;
                newPosition.y += (2 - distanceToGround) * Time.deltaTime * forceUp;
                transform.position = newPosition;
            }
            
        }
    }
}
