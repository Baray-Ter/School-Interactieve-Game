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
/*    public delegate void ClickAction(TextAsset item);
    public static event ClickAction OnClicked;*/


    Camera mainCamera;

    [SerializeField] LayerMask layerToIgnore;

    TextAsset information;

    void Start()
    {
        mainCamera = Camera.main;
    }

    public void MouseRightClick(InputAction.CallbackContext context)
    {

        if (context.started)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Perform the raycast with layer mask
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, ~layerToIgnore))
            {

                if (hit.collider.gameObject.GetComponentInParent<PartInformation>() != null)
                {
                    information = hit.collider.gameObject.GetComponentInParent<PartInformation>().Information;

                    EventPublisher<GameObject> gameObjectPublisher = new EventPublisher<GameObject>();

                    // Raise the event with some data
                    gameObjectPublisher.RaiseEvent(hit.collider.gameObject);
                    //eventPublisher.RaiseEvent(storeText.referenceToText);
                }
                else
                {
                    Debug.LogWarning("No Information Detected");
                    return;
                }

                EventPublisher<TextAsset> informationPublisher = new EventPublisher<TextAsset>();
                informationPublisher.RaiseEvent(information);
            }
        }
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
        // Raise the event by invoking the delegate\
        MyEvent?.Invoke(data);
    }
}