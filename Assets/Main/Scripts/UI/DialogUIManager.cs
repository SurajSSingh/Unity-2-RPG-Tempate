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
    }

    
    public void RecieveDialogueBranch()
    {
        // Add branch info here
    }

    public void NextDialogue()
    {
        DeactiveDialogue(); // Remove this and
       // add next Dialogue mechanism here

    }
}
