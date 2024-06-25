using System.Collections;
using System.Collections.Generic;
//using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float mouseSensitivity = 2f;
    // private float verticalRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Lock the mouse to avoid cursor out of the game window
        Cursor.visible = false; // hide the Cursor

    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        PlayRotate();
    }

    void PlayerMove()
    {
        float moveForwardBackward = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float moveRightLeft = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Translate(moveForwardBackward, 0, moveRightLeft); //transform.position return the absolute position (static specify)，transform.Translate return the move position(dynamic specify)
    }

    void PlayRotate()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        // float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
        transform.Rotate(0, mouseX, 0);
    }
}
