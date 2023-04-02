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

    private InputAction _scrollAction;

    private Vector2 _scroll;
    
    [Range(24f, 60f)] public float zoomValue;
    
    private void Awake()
    {

    }

    private void Start()
    {
        _mainCamera = Camera.main;
    }

    private void FixedUpdate()
    {
        if (BetweenBounds(_mainCamera.fieldOfView, 24, 60))
        {
            if (Mouse.current.scroll.ReadValue().y > 0 && _mainCamera.fieldOfView > 24)
            {
                var fieldOfView = _mainCamera.fieldOfView;
            
                fieldOfView += 1;
            
                _mainCamera.fieldOfView = fieldOfView;
            }

            if (Mouse.current.scroll.ReadValue().y < 0 && _mainCamera.fieldOfView < 60)
            {
                var fieldOfView = _mainCamera.fieldOfView;
            
                fieldOfView -= 1;
            
                _mainCamera.fieldOfView = fieldOfView;
            }
            
            return;
        }
        
        //out of bounds camera detection
        _mainCamera.fieldOfView = OutOfBounds(_mainCamera.fieldOfView, 24, 60);
    }

    private bool BetweenBounds(float i, float min, float max)
    {
        if (i < max && i > min)
        {
            return true;
        }

        Debug.Log("returned false");
        return false;
    }

    private float OutOfBounds(float i, float min, float max)
    {
        if (min - i > 0)
        {
            return min + 0.1f;
        }

        if (max - i <= 0)
        {
            return max - 0.1f;
        }

        return _mainCamera.fieldOfView;
    }
}
