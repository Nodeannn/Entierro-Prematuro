using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private float typingSpeed = 0.03f;

    private Dialogue currentDialogue;
    private int index;
    private bool isTyping;

    public void StartDialogue(Dialogue dialogue)
    {
        currentDialogue = dialogue;
        index = 0;
        ShowLine();
    }

    public void NextLine()
    {
        if (isTyping) return;

        if (index < currentDialogue.lines.Count - 1)
        {
            index++;
            ShowLine();
        }
        else
        {
            EndDialogue();
        }
    }

    private void ShowLine()
    {
        StopAllCoroutines();
        var line = currentDialogue.lines[index];
        nameText.text = line.speaker;
        StartCoroutine(TypeText(line.text));
    }

    private IEnumerator TypeText(string line)
    {
        isTyping = true;
        dialogueText.text = "";

        foreach (char c in line)
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;
    }

    private void EndDialogue()
    {
        dialogueText.text = "";
        nameText.text = "";
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            NextLine();
        }
    }
}
