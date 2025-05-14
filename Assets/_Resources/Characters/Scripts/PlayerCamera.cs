using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    private Player player;
    [SerializeField] private float mouseX, mouseY, rotationX, rotationY;

    [Header("Fix Camera")]
    [SerializeField] private bool displayFix;
    [SerializeField] private float radiusFix = 0.5f;
    [SerializeField] private float directionFix;
    private bool displayCursor = false;

    private void Start()
    {
        player = GetComponent<Player>();
        player.cameraMain.SetParent(null);
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        _Cursor();
        _Camera_FL();
        _Camera_Move();
        _Fix_Camera();
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
        player.cameraMain.position = transform.position;
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
    private void _Fix_Camera()
    {
        //if (Physics.SphereCast(player.camera03.position, radiusFix, Vector3.down, out RaycastHit hit , directionFix, player.layerGround))
        //{
        //    Debug.Log("Error");
        //}
        
    }
    private void OnDrawGizmos()
    {
        if(displayFix)
        {
            Gizmos.DrawWireSphere(player.camera03.position, radiusFix);
            Gizmos.DrawLine(player.camera03.position, player.camera03.position + Vector3.down * directionFix);
        }
    }
}
