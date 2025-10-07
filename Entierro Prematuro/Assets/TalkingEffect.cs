using System.Collections;
using TMPro;
using UnityEngine;

public class TalkingEffect : MonoBehaviour
{
    [SerializeField] private TMP_Text textBox;
    [TextArea]
    [SerializeField] private string fullText; 
    [SerializeField] private float delay = 0.05f;

    private void Start()
    {
        StartCoroutine(ShowText());
    }

    private IEnumerator ShowText()
    {
        textBox.text = "";
        foreach (char c in fullText)
        {
            textBox.text += c;
            yield return new WaitForSeconds(delay);
        }
    }
}
