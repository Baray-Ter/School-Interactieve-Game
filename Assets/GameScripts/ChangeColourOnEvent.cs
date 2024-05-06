using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColourOnEvent : MonoBehaviour
{
    public Color newColour;
    public float newColourAlpha;

    private Color oldColour;
    private float oldColourAlpha;

    private GameObject _defaultGameObject;

    // Subscribe to the event 
    private void Start()
    {
        EventPublisher<GameObject>.MyEvent += StaticEventHandler;
    }

    public void StaticEventHandler(GameObject data)
    {
        if (_defaultGameObject != null)
        {
            _defaultGameObject.GetComponent<MeshRenderer>().material.color = oldColour;
        }

        _defaultGameObject = data;

        oldColour = data.GetComponent<MeshRenderer>().material.color;

        data.GetComponent<MeshRenderer>().material.color = newColour;
    }
}