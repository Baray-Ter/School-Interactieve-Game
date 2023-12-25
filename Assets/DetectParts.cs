    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using Unity.VisualScripting;
using System.Linq;
using System;

public class DetectParts : MonoBehaviour
{
    public delegate void ClickAction (TextAsset item);
    public static event ClickAction OnClicked;


    private StoreText storeText;

    Camera mainCamera;

    [SerializeField] LayerMask layerToIgnore;
    

    void Start()
    {
        mainCamera = Camera.main;
    }

    public void MouseRightClick(InputAction.CallbackContext context){

        if (context.started)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Perform the raycast with layer mask
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, ~layerToIgnore))
            {

                if (hit.collider.gameObject.GetComponentInParent<StoreText>() != null)
                {
                    storeText = hit.collider.gameObject.GetComponentInParent<StoreText>();
                }

                //OnClicked?.Invoke(storeText.referenceToText);

                EventPublisher<object> eventPublisher = new EventPublisher<object>();

                // Raise the event with some data
                eventPublisher.RaiseEvent(hit.collider.gameObject.GetComponent<MeshRenderer>().material);
                eventPublisher.RaiseEvent(storeText.referenceToText);
            }
        }
	}

    private void eventSub(){

    }
}

public delegate void MyGenericDelegate<T>(T data);
public class EventPublisher<T>
{
    // Declare an event using the generic delegate
    public static event MyGenericDelegate<T> MyEvent;
 
    // Method to trigger the event
    public void RaiseEvent(T data)
    {
        // Check if there are subscribers to the event
        // Raise the event by invoking the delegate
        MyEvent?.Invoke(data);
    }
}