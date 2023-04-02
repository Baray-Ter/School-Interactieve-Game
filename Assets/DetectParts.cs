using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DetectParts : MonoBehaviour
{
    public LayerMask ignoredLayerMask;

    private void FixedUpdate()
    {
        RaycastHit hitInfo;

        Vector2 mousePosition = Mouse.current.position.ReadValue();

        Ray rayOrigin = Camera.main.ScreenPointToRay(mousePosition);

        if (Physics.Raycast(rayOrigin, out hitInfo))
        {
            Debug.Log(hitInfo.transform.name);

        }
    }
}
