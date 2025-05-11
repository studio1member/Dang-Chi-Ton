using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFix : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private bool checkVar;
    [SerializeField] private float speed = 1f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Wall"))
        {
            checkVar = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Wall"))
        {
            checkVar = false;
        }
    }
    private void Update()
    {
        float direction = Vector3.Distance(transform.position, player.cameraMain.position);
        if (checkVar)
        {
            if (direction > 1f && player.zoom) player.camera03.position = Vector3.MoveTowards(transform.position, player.cameraMain.position, speed * Time.deltaTime);
        }
        else
        {
            if (direction < 4.5f && !player.zoom) player.camera03.position = Vector3.MoveTowards(transform.position, player.cameraMain.position, -1 * speed * Time.deltaTime);
        }
    }
}
