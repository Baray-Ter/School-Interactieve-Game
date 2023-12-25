using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayText : MonoBehaviour
{
    public TextMeshProUGUI textMeshProUGUI;

    private void OnEnable() {

        //DetectParts.OnClicked += WriteText;
        EventPublisher<TextAsset>.MyEvent += WriteText;
    }

    public void WriteText(TextAsset textAsset){

        Debug.Log(textAsset);
        textMeshProUGUI.text = textAsset.text;
    }
}
