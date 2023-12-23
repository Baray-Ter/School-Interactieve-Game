using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.Universal.ShaderGUI;
using UnityEngine;

public class MouseTest : MonoBehaviour
{
    private void OnMouseDown() {
        
        Debug.Log(transform.name);
    }
}
