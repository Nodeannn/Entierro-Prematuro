using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;


public class ChoiceManager3D : MonoBehaviour
{
    [SerializeField] private GameObject choicesPanel;
    [SerializeField] private Button[] choiceButtons;
    [SerializeField] private GameObject dialogueText;
    [SerializeField] private GameObject speakerText;
    [SerializeField] private GameObject speakerBox;

    private Action<int> onChoiceSelected;

    public void ShowChoices(string[] options, Action<int> callback)
    {
        onChoiceSelected = callback;

        choicesPanel.SetActive(true);
        dialogueText.SetActive(false);
        speakerText.SetActive(false);
        speakerBox.SetActive(false);

        for (int i = 0; i < choiceButtons.Length; i++)
        {
            if (i < options.Length)
            {
                choiceButtons[i].gameObject.SetActive(true);
                choiceButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = options[i];
                int index = i;
                choiceButtons[i].onClick.RemoveAllListeners();
                choiceButtons[i].onClick.AddListener(() => SelectChoice(index));
            }
            else
            {
                choiceButtons[i].gameObject.SetActive(false);
            }
        }
    }

    private void SelectChoice(int index)
    {
        choicesPanel.SetActive(false);

        onChoiceSelected?.Invoke(index);
    }
}
