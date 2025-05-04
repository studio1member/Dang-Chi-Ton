using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFix : MonoBehaviour
{
    private Player player;
    private bool checkVar;
    [SerializeField] private float speed;
    private void Start()
    {
        player = Player.instance.GetComponent<Player>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Wall"))
        {
            checkVar = true;
            speed = 1f;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Wall"))
        {
            checkVar = false;
            speed = 0f;
        }
    }
    private void Update()
    {
        if (checkVar)
        {
            
        }
        else
        {

        }
    }
}
