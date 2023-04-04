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
    
    [Range(24f, 60f)] public float zoomValue;

    private void Start()
    {
        _mainCamera = Camera.main;
    }

    public void ScrollFOV(InputAction.CallbackContext context){

        if (context.started)
        {
            if (context.ReadValue<float>() > 0 && _mainCamera.fieldOfView < 64)
            {
               var fieldOfView = _mainCamera.fieldOfView;
        
                fieldOfView += 1;
            
                _mainCamera.fieldOfView = fieldOfView;

                return; 
            }

            if (context.ReadValue<float>() < 0 && _mainCamera.fieldOfView > 20)
            {
               var fieldOfView = _mainCamera.fieldOfView;
        
                fieldOfView -= 1;
            
                _mainCamera.fieldOfView = fieldOfView;

                return; 
            }
        }
    }
}
