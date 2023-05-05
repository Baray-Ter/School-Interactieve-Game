using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ModelRotation : MonoBehaviour
{
    public float rotationSpeed = 10f;

    private void FixedUpdate() {
        
        if (Mouse.current.leftButton.isPressed)
        {
            float rotateX = Input.GetAxis("Mouse X") * rotationSpeed * Mathf.Deg2Rad;
            float rotateY = Input.GetAxis("Mouse Y") * rotationSpeed * Mathf.Deg2Rad;

            transform.Rotate(Vector3.up, -rotateX);
            transform.Rotate(Vector3.right, rotateY);
        }
    }
}
