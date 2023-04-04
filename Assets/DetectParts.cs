using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class DetectParts : MonoBehaviour
{
    public LayerMask ignoredLayerMask;

    private TextAsset getTextAsset;

    public TextMeshProUGUI informationBubble;

    private void FixedUpdate()
    {
        RaycastHit hitInfo;

        Vector2 mousePosition = Mouse.current.position.ReadValue();

        Ray rayOrigin = Camera.main.ScreenPointToRay(mousePosition);

        if (Physics.Raycast(rayOrigin, out hitInfo))
        {
            if (hitInfo.transform.GetComponent<HandleText>().textInformation == null)
            {
                return;
            }

            Debug.Log(hitInfo.transform.name);

            getTextAsset = hitInfo.transform.GetComponent<HandleText>().textInformation;

            informationBubble.text = getTextAsset.text;
        }
    }
}
