using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Branch", menuName = "CustomObject/Dialogue/Branch")]
public class DialogueBranch : ScriptableObject
{
    public string dialogueID = "";
    public List<string> DialogueLines;
    public List<DialogueResponse> ResponseOption;
}
