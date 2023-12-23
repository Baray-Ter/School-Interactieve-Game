using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class ModelRotation : MonoBehaviour
{
    public float rotationSpeed = 10f;

    public Rigidbody rb;
    public float strength = 10;
    public float rotX;
    public float rotY;
    bool rotate;

    private Vector3 target;
    private float speed = 1;

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

    private void Update()
    {
        target = Camera.main.ScreenToViewportPoint(Mouse.current.position.ReadValue() * 15);




        /*        target = Camera.main.ScreenToViewportPoint(Mouse.current.position.ReadValue() * 10);

                // Determine which direction to rotate towards
                Vector3 targetDirection = target - transform.position;

                // The step size is equal to speed times frame time.
                float singleStep = speed * Time.deltaTime;

                // Rotate the forward vector towards the target direction by one step
                Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

                // Draw a ray pointing at our target in
                Debug.DrawRay(transform.position, newDirection, Color.red);

                // Calculate a rotation a step closer to the target and applies rotation to this object
                transform.rotation = Quaternion.LookRotation(newDirection);*/
    }

    void FixedUpdate()
    {

    }
    /*    private void OnMouseDrag() {

            if (Mouse.current.leftButton.isPressed)
            {
                float rotateX = Input.GetAxis("Mouse X") * rotationSpeed * Mathf.Deg2Rad;
                float rotateY = Input.GetAxis("Mouse Y") * rotationSpeed * Mathf.Deg2Rad;

                transform.Rotate(Vector3.up, -rotateX);
                transform.Rotate(Vector3.right, rotateY);
            }
        }*/
}
