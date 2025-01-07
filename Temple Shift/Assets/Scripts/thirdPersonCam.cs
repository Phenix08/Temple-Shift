using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thirdPersonCam : MonoBehaviour
{
    [Header("References")]
    public Transform orientation;
    public new Transform camera;
    public Transform player;
    public Transform playerObj;
    public Rigidbody rb;

    public float rotationSpeed;

    public bool AWSDControls;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void Update()
    {   
        // rotate orientation
        Vector3 viewDirection = new Vector3 (0,0,0)- new Vector3 (camera.position.x, player.position.y, camera.position.z);
        orientation.forward = viewDirection.normalized;

        // rotate player object
        float horizontalInput = 0f;
        float verticalInput = 0f;
        if (AWSDControls)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");
        } 
        else
        {
            horizontalInput = Input.GetAxis("HorizontalArrow");
            verticalInput = Input.GetAxis("VerticalArrow");
        }
        
        Vector3 inputDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if (inputDirection != Vector3.zero)
            playerObj.forward = Vector3.Slerp(playerObj.forward, inputDirection.normalized, Time.deltaTime * rotationSpeed);
    }
}
