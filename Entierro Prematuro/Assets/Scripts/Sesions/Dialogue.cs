using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDialogue", menuName = "Dialogue/Conversation")]
public class Dialogue : ScriptableObject
{
    public List<DialogueLine> lines = new List<DialogueLine>();
    public bool mostrarOpcionesAlFinal = true;
}
