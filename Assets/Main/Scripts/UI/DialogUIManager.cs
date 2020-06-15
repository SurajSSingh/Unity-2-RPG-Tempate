using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogUIManager : MonoBehaviour
{
    public GameObject background;
    public GameObject mainText;
    public GameObject responseTab;
    public GameObject continueText;
    public List<Button> responsesHolder;

    [SerializeField]
    private int currentIndex = 0;
    [SerializeField]
    private int responses = 0;

    //Students need to add
    private DialogueBranch branch;

    // Start is called before the first frame update
    void Start()
    {
        DeactiveDialogue();
    }

    public void ActiveDialogue()
    {
        background.SetActive(true);
        mainText.SetActive(true);
        continueText.SetActive(true);
        responseTab.SetActive(true);
        foreach (Button response in responsesHolder)
        {
            response.gameObject.SetActive(false);
        }
    }

    void DeactiveDialogue()
    {
        background.SetActive(false);
        mainText.SetActive(false);
        continueText.SetActive(false);
        responseTab.SetActive(false);
        foreach (Button response in responsesHolder)
        {
            response.gameObject.SetActive(false);
        }
    }

    public void NextBranch(int branchSelect)
    {
        // Add ReciveDialogueBranch with newBranch being next branch
        ReciveDialogueBranch(branch.ResponseOption[branchSelect].nextBranch);
        ActiveDialogue();
        NextDialogue();
    }

    // Student create below
    public void ReciveDialogueBranch(DialogueBranch newBranch)
    {
        this.branch = newBranch;
        responses = Mathf.Clamp(branch.ResponseOption.Count,0,3);
        currentIndex = 0;
    }

    public void NextDialogue()
    {
        // If at end of branch
        if (currentIndex >= branch.DialogueLines.Count)
        {
            // No response -> End dialogue
            if (responses == 0)
            {
                DeactiveDialogue();
            }
            else
            {
                continueText.SetActive(false);
                for (int i = 0; i < responses; i++)
                {
                    if (i >= 3)
                    {
                        break;
                    }

                    responsesHolder[i].gameObject.SetActive(true);
                    responsesHolder[i].
                        GetComponentInChildren<TextMeshProUGUI>()
                        .text = branch.ResponseOption[i].Text;
                }
            }
        }
        else
        {
            mainText.GetComponent<TextMeshProUGUI>().text = branch.DialogueLines[currentIndex];
            continueText.SetActive(true);
            currentIndex++;
        }
    }
}
