using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private float mouseX, mouseY, rotationX, rotationY;
    private bool displayCursor = false;

    private void Start()
    {
        player.cameraMain.SetParent(null);
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        _Cursor();
        _Camera_FL();
        _Camera_Move();
    }
    private void _Cursor()
    {
        if (Input.GetKeyDown(KeyCode.BackQuote) && displayCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            displayCursor = false;
        }
        else if (Input.GetKeyDown(KeyCode.BackQuote))
        {
            Cursor.lockState = CursorLockMode.None;
            displayCursor = true;
        }
    }
    private void _Camera_FL()
    {
        this.player.cameraMain.position = this.player.transform.position;
        if(Physics.Raycast(this.player.camera02.position, -this.player.camera02.forward,out RaycastHit hit, 5f))
        {
            //Vector3 pos = new Vector3(hit.point.x, hit.point.y, hit.point.z + 1f);
            this.player.camera03.position = hit.point;
        }
        else
        {
            this.player.camera03.localPosition = new Vector3(0, 0, this.player.camera02.localPosition.z - 4f);
        }
    }
    private void _Camera_Move()
    {
        mouseX = Input.GetAxis("Mouse Y");
        mouseY = Input.GetAxis("Mouse X");
        rotationY += mouseY;
        rotationX -= mouseX;

        player.cameraMain.localRotation = Quaternion.Euler(0, rotationY, 0);
        player.camera01.localRotation = Quaternion.Euler(rotationX, 0, 0);
    }
}
