using System;
using System.Collections;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraZoomOptions : MonoBehaviour
{
    private Camera _mainCamera;
    
    public InputActionAsset actions;

    public float addedValue = 1;

    private InputAction _scrollAction;

    private Vector2 _scroll;
    
    [Tooltip("How far camera gets zoomed out")] public float maxZoomOut = 60;

    [Tooltip("How far camera gets zoomed in")] public float minZoomIn = 24;

    [Tooltip("How fast camera gets zoomed in or out")] public float zoomSpeed = 1;

    private void Start()
    {
        _mainCamera = Camera.main;
    }

    public void ScrollFOV(InputAction.CallbackContext context){

        if (context.started)
        {
            if (context.ReadValue<float>() > 0 && _mainCamera.fieldOfView < maxZoomOut)
            {
               var fieldOfView = _mainCamera.fieldOfView;
        
                fieldOfView += zoomSpeed;
            
                _mainCamera.fieldOfView = fieldOfView;

                return; 
            }

            if (context.ReadValue<float>() < 0 && _mainCamera.fieldOfView > minZoomIn)
            {
               var fieldOfView = _mainCamera.fieldOfView;
        
                fieldOfView -= zoomSpeed;
            
                _mainCamera.fieldOfView = fieldOfView;

                return; 
            }
        }
    }
}
