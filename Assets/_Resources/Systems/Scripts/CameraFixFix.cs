using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFixFix : MonoBehaviour
{
    Player player;
    private void Start()
    {
        player = Player.instance.GetComponent<Player>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Wall"))
        {
            player.zoom = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Wall"))
        {
            player.zoom = false;
        }
    }
}
