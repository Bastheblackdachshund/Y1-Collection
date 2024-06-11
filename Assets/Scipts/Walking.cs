using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walking : MonoBehaviour
{
    private float currentSpeed;
    public float walkingSpeed = 10f;
    public float runningSpeed = 15f;

    public float gravity = -0.5f;
    public float jumpSpeed = 0.0f;
    private float baseLineGravity;

    private float moveX;
    private float moveZ;
    private Vector3 move;

    public CharacterController characterController;
    private Rigidbody rb;

    public Camera playerCamera;
    public float mouseSensitivity = 100f;
    private float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentSpeed = walkingSpeed;
        baseLineGravity = gravity;

        // Lock the cursor to the center of the screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // Handle mouse input for camera rotation
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Limit the vertical rotation to avoid flipping the camera

        playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);

        // Handle movement input
        moveX = Input.GetAxis("Horizontal") * currentSpeed * Time.deltaTime;
        moveZ = Input.GetAxis("Vertical") * currentSpeed * Time.deltaTime;

        move = transform.right * moveX +
               transform.up * gravity +
               transform.forward * moveZ;

        characterController.Move(move);
    }
}
