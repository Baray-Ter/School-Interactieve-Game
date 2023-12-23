using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using Unity.VisualScripting;
using System.Linq;

public class DetectParts : MonoBehaviour
{
    private TextAsset getTextAsset;

    public TextMeshProUGUI informationText;

    Camera mainCamera;

    public GameObject textGameObject;

    private bool setTextGameObjectState;

    [SerializeField] LayerMask UseThisLayer;

    void Start()
    {
        mainCamera = Camera.main;
        //IgnoreLayer = ~IgnoreLayer;
    }

    private void FixedUpdate()
    {
        // // Vector3 mousePos = Mouse.current.position.ReadValue();
        // // mousePos.z = 100f;
        // // mousePos = mainCamera.ScreenToWorldPoint(mousePos);
        // // Debug.DrawRay(transform.position, mousePos - transform.position, Color.blue);
        // // Debug.Log(transform.name);

        // Vector2 _mousePosFromCamera = Mouse.current.position.ReadValue();
        // _mousePosFromCamera = mainCamera.ScreenToWorldPoint(_mousePosFromCamera);
        // // RaycastHit raycastHit = Physics.Raycast(transform.position, _mousePosFromCamera);
        // // Debug.DrawRay(transform.position, _mousePosFromCamera, Color.red);
        // // Debug.Log(transform.name);

        // // RaycastHit hit = Physics.Raycast(transform.position, _mousePosFromCamera, Mathf.Infinity);
        // // Does the ray intersect any objects excluding the player layer

        // RaycastHit hit;
        // if (Physics.Raycast(transform.position, _mousePosFromCamera, out hit, Mathf.Infinity))
        // {
        //     Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
        //     Debug.Log("Did Hit");
        // }
    }

    public void MouseLeftClick(InputAction.CallbackContext context){

        if (context.started)
        {
            RaycastHit hitPoint;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            if(Physics.Raycast(ray, out hitPoint, Mathf.Infinity))
            {
                Debug.Log(hitPoint.collider.name);
            }
        }
	}
}