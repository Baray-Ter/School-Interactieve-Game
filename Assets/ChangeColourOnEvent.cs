using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColourOnEvent : MonoBehaviour
{
    public Color ChangeColourToThis;

    // Subscribe to the event 
    private void Start() {

        EventPublisher<Material>.MyEvent += StaticEventHandler;
    }

    public void StaticEventHandler(Material data)
    {
        Debug.Log("Static event triggered with data: " + data);
    }
}