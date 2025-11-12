using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

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

    [Header("End Route")]

    [SerializeField] private string finalMalo = "Final_Malo";
    [SerializeField] private string finalMedio = "Final_Medio";
    [SerializeField] private string finalBueno = "Final_Bueno";

    [SerializeField] private float punMaxBuena = 15;
    [SerializeField] private float punMaxMedia = 14;
    [SerializeField] private float punMinMedia = 9;
    [SerializeField] private float punMaxMala = 8;
    [SerializeField] private float punMinMala = 0;

    private int index;
    private bool isTyping;
    private string currentLine = "";
    private Coroutine typingCoroutine;

    private Dialogue siguienteDialogo = null;

    [Header("Config Opciones")]
    [SerializeField] public int pointsA = 0;
    [SerializeField] public int pointsB = 0;
    [SerializeField] public int pointsC = 0;

    [SerializeField] private string proxEscena = "";

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

        if (!mainDialogue.mostrarOpcionesAlFinal)
        {
            if (!string.IsNullOrEmpty(proxEscena))
            {
                SceneManager.LoadScene(proxEscena);
                return;
            }

            if (mainDialogue.esUltimaSesion && GameManager.instance != null)
            {
                int finalScore = GameManager.instance.GetScore();

                if (finalScore >= punMaxBuena)
                {
                    SceneManager.LoadScene(finalBueno);
                }
                else if (finalScore >= punMinMedia && finalScore <= punMaxMedia)
                {
                    SceneManager.LoadScene(finalMedio);
                }
                else if (finalScore >= punMinMala && finalScore <= punMaxMala)
                {
                    SceneManager.LoadScene(finalMalo);
                }
            }
            else
            {
                Debug.LogWarning("GameManager no encontrado, no se puede determinar el final.");
            }

            Debug.Log("Diálogo terminado sin opciones ni escena asignada.");
            return;
        }

        string[] opciones = { Opcion1, Opcion2, Opcion3 };
        choiceManager.ShowChoices(opciones, OnChoiceSelected);
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
                if (GameManager.instance != null)
                {
                    GameManager.instance.AddScore(pointsA);
                }
                break;

            case 1:
                dialogueTextComponent.SetActive(true);
                speakerText.SetActive(true);
                speakerBox.SetActive(true);

                StartDialogue(bDialogue);
                if (GameManager.instance != null)
                {
                    GameManager.instance.AddScore(pointsB);
                }
                break;

            case 2:
                dialogueTextComponent.SetActive(true);
                speakerText.SetActive(true);
                speakerBox.SetActive(true);

                StartDialogue(cDialogue);
                if (GameManager.instance != null)
                {
                    GameManager.instance.AddScore(pointsC);
                }
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
