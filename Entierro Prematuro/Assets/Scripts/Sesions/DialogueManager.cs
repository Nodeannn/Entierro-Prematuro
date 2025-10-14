using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.VirtualTexturing;

public class DialogueManager : MonoBehaviour
{
    [Header("Componentes")]
    [SerializeField] private ChoiceManager choiceManager;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private GameObject dialogueTextComponent;
    [SerializeField] private GameObject speakerText;
    [SerializeField] private GameObject speakerBox;
    [SerializeField] private FatherView characterView;

    [Header("Texto Config")]
    [SerializeField] private float typingSpeed = 0.03f;

    [Header("Texto Opciones")]
    [SerializeField] private string Opcion1 = "";
    [SerializeField] private string Opcion2 = "";
    [SerializeField] private string Opcion3 = "";

    [Header("Dialogos")]
    [SerializeField] private Dialogue mainDialogue;
    [SerializeField] private Dialogue aDialogue;
    [SerializeField] private Dialogue bDialogue;
    [SerializeField] private Dialogue cDialogue;

    private int index;
    private bool isTyping;
    private string currentLine = "";
    private Coroutine typingCoroutine;

    private bool mostrarOpcionesAlFinal = true;
    private string proximaEscena = "";
    private Dialogue siguienteDialogo = null;

    [Header("Config Opciones")]
    [SerializeField] public int pointsA = 0;
    [SerializeField] public int pointsB = 0;
    [SerializeField] public int pointsC = 0;

    [SerializeField] private string proxEscena = "";

    static int puntuacion = 0;

    public void StartDialogue(Dialogue dialogue)
    {
        mainDialogue = dialogue;
        index = 0;
        ShowLine();
    }

    public void NextLine()
    {
        if (isTyping) return;

        if (index < mainDialogue.lines.Count - 1)
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
        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);

        var line = mainDialogue.lines[index];
        nameText.text = line.speaker;
        currentLine = line.text;

        if (characterView != null)
            characterView.ApplyDialogueLineBools(line);

        dialogueText.text = "";
        typingCoroutine = StartCoroutine(TypeText(currentLine));
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
        typingCoroutine = null;
    }

    private void EndDialogue()
    {
        dialogueText.text = "";
        nameText.text = "";

        if (siguienteDialogo != null)
        {
            StartDialogue(siguienteDialogo);
            siguienteDialogo = null;
            return;
        }

        if (!string.IsNullOrEmpty(proximaEscena))
        {
            SceneManager.LoadScene(proximaEscena);
            return;
        }

        if (mostrarOpcionesAlFinal)
        {
            string[] opciones = { Opcion1, Opcion2, Opcion3 };
            choiceManager.ShowChoices(opciones, OnChoiceSelected);
        }
    }

    private void OnChoiceSelected(int index)
    {
        switch (index)
        {
            case 0:
                dialogueTextComponent.SetActive(true);
                speakerText.SetActive(true);
                speakerBox.SetActive(true);

                StartDialogue(aDialogue);
                puntuacion += pointsA;
                proximaEscena = proxEscena;
                break;

            case 1:
                dialogueTextComponent.SetActive(true);
                speakerText.SetActive(true);
                speakerBox.SetActive(true);

                StartDialogue(bDialogue);
                puntuacion += pointsB;
                proximaEscena = proxEscena;
                break;

            case 2:
                dialogueTextComponent.SetActive(true);
                speakerText.SetActive(true);
                speakerBox.SetActive(true);

                StartDialogue(cDialogue);
                puntuacion += pointsC;
                proximaEscena = proxEscena;
                break;
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            if (isTyping)
            {
                StopCoroutine(typingCoroutine);
                dialogueText.text = currentLine;
                isTyping = false;
                typingCoroutine = null;
            }
            else
            {
                NextLine();
            }
        }
    }
}
