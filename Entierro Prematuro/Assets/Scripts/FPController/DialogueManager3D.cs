using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
public class DialogueManager3D : MonoBehaviour
{
    [Header("Componentes")]
    [SerializeField] private ChoiceManager3D choiceManager;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private GameObject dialogueTextComponent;
    [SerializeField] private GameObject speakerText;
    [SerializeField] private GameObject speakerBox;
    [SerializeField] private GameObject DialogBox;
    [SerializeField] private FPController player;
    [SerializeField] private GameObject Interact;

    [Header("Texto Config")]
    [SerializeField] private float typingSpeed = 0.03f;
    [SerializeField] private bool unlockPlayer = true;

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

    [Header("Audio")]
    public AudioClip vozPadre;
    public AudioClip vozPsiquiatra;
    public AudioSource audioSource;

    private AudioClip vozActual;

    private int index;
    private bool isTyping;
    private string currentLine = "";
    private Coroutine typingCoroutine;

    [Header("Config Opciones")]
    [SerializeField] public int pointsA = 0;
    [SerializeField] public int pointsB = 0;
    [SerializeField] public int pointsC = 0;

    private bool dialogueActive = false;

    public void StartDialogue(Dialogue dialogue)
    {
        mainDialogue = dialogue;
        index = 0;

        dialogueActive = true;
        dialogueTextComponent.SetActive(true);
        speakerText.SetActive(true);
        speakerBox.SetActive(true);
        DialogBox.SetActive(true);
        Interact.SetActive(false);

        if (player != null)
        {
            player.LockPlayerControls(true);
        }

        ShowLine();
    }

    public void NextLine()
    {
        if (!dialogueActive || isTyping) return;

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

        SetVoiceBySpeaker(line.speaker);

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

            if (!char.IsWhiteSpace(c) && vozActual != null)
            {
                audioSource.pitch = Random.Range(0.95f, 1.05f);
                audioSource.PlayOneShot(vozActual);
            }

            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;
        typingCoroutine = null;
    }

    private void EndDialogue()
    {
        dialogueText.text = "";
        nameText.text = "";
        dialogueActive = false;

        dialogueTextComponent.SetActive(false);
        speakerText.SetActive(false);
        speakerBox.SetActive(false);
        DialogBox.SetActive(false);
        Interact.SetActive(true);

        if (mainDialogue.mostrarOpcionesAlFinal)
        {
            DialogBox.SetActive(true);
            string[] opciones = { Opcion1, Opcion2, Opcion3 };
            choiceManager.ShowChoices(opciones, OnChoiceSelected);
            return;
        }

        if (mainDialogue.esUltimaSesion)
        {
            StartCoroutine(EsperarYEvaluarFinal());
        }

        if (player != null)
            player.LockPlayerControls(false);
    }
    private void OnChoiceSelected(int index)
    {
        switch (index)
        {
            case 0:
                dialogueTextComponent.SetActive(true);
                speakerText.SetActive(true);
                speakerBox.SetActive(true);
                DialogBox.SetActive(true);

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
                DialogBox.SetActive(true);

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
                DialogBox.SetActive(true);
                
                StartDialogue(cDialogue);
                if (GameManager.instance != null)
                {
                    GameManager.instance.AddScore(pointsC);
                }
                break;
        }
        if (unlockPlayer)
        {
            StartCoroutine(WaitUntilDialogueEnds());
        }
    }

    private IEnumerator WaitUntilDialogueEnds()
    {
        while (dialogueActive)
            yield return null;

        if (player != null)
            player.LockPlayerControls(false);
    }

    private IEnumerator EsperarYEvaluarFinal()
    {
 
        yield return null;

        if (GameManager.instance == null)
        {
            Debug.LogError("⚠️ GameManager no encontrado. No se puede determinar el final.");
            yield break;
        }

        int finalScore = GameManager.instance.GetScore();
        Debug.Log($"Puntaje final detectado: {finalScore}");

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

    void SetVoiceBySpeaker(string speaker)
    {
        switch (speaker)
        {
            case "Padre":
                vozActual = vozPadre;
                break;

            case "Psiquiatra":
                vozActual = vozPsiquiatra;
                break;
            default:
                vozActual = null;
                break;
        }

        Debug.Log("Speaker: " + speaker);
        Debug.Log("Voz asignada: " + (vozActual != null ? vozActual.name : "NULL"));
    }

    void Update()
    {
        if (!dialogueActive) return;

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
