    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class DetectParts : MonoBehaviour
{
    private TextAsset getTextAsset;

    public TextMeshProUGUI informationText;

    Camera mainCamera;

    public GameObject textGameObject;

    private bool setTextGameObjectState;

    [SerializeField] LayerMask ignoreMotherGameObjectLayer;

    void Start()
    {
        mainCamera = Camera.main;
        ignoreMotherGameObjectLayer = ~ignoreMotherGameObjectLayer;
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
            Vector3 mousePos = Mouse.current.position.ReadValue();

            mousePos.z = 100f;

            mousePos = mainCamera.ScreenToWorldPoint(mousePos);

            Debug.DrawRay(transform.position, mousePos - transform.position, Color.yellow);

            RaycastHit hit;

            if (Physics.Raycast(transform.position, mousePos, out hit, Mathf.Infinity))
            {
                Debug.Log(hit.transform.name);
            }
        }

    }

    public void MouseRightClick(InputAction.CallbackContext context){
        
        if (Mouse.current.rightButton.isPressed && context.started)
        {
            setTextGameObjectState = !setTextGameObjectState;
            textGameObject.SetActive(setTextGameObjectState);
        }
    }


}