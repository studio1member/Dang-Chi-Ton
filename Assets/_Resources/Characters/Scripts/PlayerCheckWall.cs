using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckWall : MonoBehaviour
{
    [SerializeField] private Player player;
    private void OnTriggerEnter(Collider other)
    {
        if (((1 << other.gameObject.layer) & player.layerGround) != 0)
        {
            player.checkWall = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (((1 << other.gameObject.layer) & player.layerGround) != 0)
        {
            player.checkWall = false;
        }
    }
}
