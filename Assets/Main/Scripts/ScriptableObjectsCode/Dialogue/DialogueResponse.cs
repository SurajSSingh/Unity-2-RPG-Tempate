using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Response", menuName = "CustomObject/Dialogue/Response")]
public class DialogueResponse : ScriptableObject
{
    public string Text;
    public DialogueBranch nextBranch;
}
