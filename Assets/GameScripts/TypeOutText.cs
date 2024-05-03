using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.Rendering;

public class TypeOutText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI m_TextMeshPro;
    private bool isCorutineRuning = false;

    private void Start()
    {
        EventPublisher<TextAsset>.MyEvent += StaticEventHandler;
    }

    public void StaticEventHandler(TextAsset data)
    {
        if (!isCorutineRuning)
        {
            StartCoroutine(TypeSentence(data.text));
            return;
        }

        StopAllCoroutines();
        m_TextMeshPro.text = string.Empty;
        isCorutineRuning = false;
        StartCoroutine(TypeSentence(data.text));
    }

    private IEnumerator TypeSentence(string sentence)
    {
        isCorutineRuning = true;

        m_TextMeshPro.text = string.Empty;

        foreach (char letter in sentence.ToCharArray())
        {
            m_TextMeshPro.text += letter;

            yield return new WaitForSeconds(0.001f);
            //yield return null;
        }

        yield break;
    }
}
