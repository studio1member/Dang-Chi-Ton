using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private float mouseX, mouseY, rotationX, rotationY;
    private bool displayCursor = false;

    public float DistanceCamera = 4f;
    private float Distance;

    public Vector3 PosCamera;
    private Vector3 Pos;

    private void Start()
    {
        this.player.cameraMain.SetParent(null);
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        _Cursor();
        _Camera_FL();
        _Camera_Move();
    }
    public void _Camera_Reset() { this.DistanceCamera = 4f; this.PosCamera = new Vector3(0.5f, 0, 0); }
    public void _Camera_FPS() { this.DistanceCamera = 0f; this.PosCamera = new Vector3(0, 0, 0); }
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
        this.Pos = Vector3.MoveTowards(this.Pos, this.PosCamera, 5f * Time.deltaTime);
        this.player.cameraMain.position = new Vector3(this.player.transform.position.x, this.player.transform.position.y + 1f, this.player.transform.position.z);

        this.player.camera02.localPosition = this.Pos;

        this.Distance = Mathf.MoveTowards(this.Distance, this.DistanceCamera, 10f * Time.deltaTime);
        if (Physics.Raycast(this.player.camera02.position, -this.player.camera02.forward, out RaycastHit hit, this.Distance)) this.player.camera03.position = hit.point;
        else this.player.camera03.localPosition = new Vector3(0, 0, this.player.camera02.localPosition.z - this.Distance);
    }
    private void _Camera_Move()
    {
        mouseX = Input.GetAxis("Mouse Y");
        mouseY = Input.GetAxis("Mouse X");
        rotationY += mouseY * this.player.sensitivity * Time.deltaTime;
        rotationX -= mouseX * this.player.sensitivity * Time.deltaTime;

        player.cameraMain.localRotation = Quaternion.Euler(0, rotationY, 0);
        player.camera01.localRotation = Quaternion.Euler(rotationX, 0, 0);
    }
}
