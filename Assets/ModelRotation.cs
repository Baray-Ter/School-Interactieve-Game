using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ModelRotation : MonoBehaviour
{
    public float rotationSpeed = 10f;

    public Rigidbody rb;
    public float strength = 10;
    public float rotX;
    public float rotY;
    bool rotate;

    private Vector3 target;

    private void OnCollisionEnter(Collision collision)
    {

    }

    private void OnMouseDrag()
    {
        if (Input.GetMouseButton(0))
        {
            rotate = true;
            rotX = Input.GetAxis("Mouse X") * strength;
            rotY = Input.GetAxis("Mouse Y") * strength;
        }
        else
        {
            rotate = false;
        }

        if (rotate)
        {
            rb.AddTorque(rotY, -rotX, 0);
        }
    }
    }

        if (Mouse.current.leftButton.isPressed)
        {
            float rotateX = Input.GetAxis("Mouse X") * rotationSpeed * Mathf.Deg2Rad;
            float rotateY = Input.GetAxis("Mouse Y") * rotationSpeed * Mathf.Deg2Rad;

            transform.Rotate(Vector3.up, -rotateX);
            transform.Rotate(Vector3.right, rotateY);
        }
    }
}
