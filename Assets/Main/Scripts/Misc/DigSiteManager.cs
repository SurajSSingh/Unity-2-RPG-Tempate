using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DigSiteManager : MonoBehaviour
{
    public GameObject popupText;
    public GameObject digPanel;
    public LootTable lt;

    public PlayerManager pm;

    [SerializeField]
    private List<int> currentVein;
    private bool isMineable = false;
    private bool inMineZone = false;

    // Start is called before the first frame update
    void Start()
    {
        pm = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
        RandomFill();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && isMineable && inMineZone)
        {
            digPanel.SetActive(true);
            pm.AddToInventory(DigMine());
        }
    }

    List<int> DigMine()
    {
        int digAmount = Random.Range(4/PlayerPrefs.GetInt(PrefNames.difficulty),
                                    16/PlayerPrefs.GetInt(PrefNames.difficulty));
        List<int> lootFound = new List<int>();
        digPanel.GetComponentInChildren<TextMeshProUGUI>().text = "";
        for (int i = 0; i < digAmount; i++)
        {
            if (currentVein.Count == 0)
            {
                isMineable = false;
                popupText.GetComponent<TextMeshProUGUI>().text = "Can't mine this just yet.";
                StartCoroutine("MineCoolDown");
                break;
            }
            digPanel.GetComponentInChildren<TextMeshProUGUI>().text += "\n" +
                lt.weightedLootItems[currentVein[currentVein.Count - 1]].itemName;
            lootFound.Add(currentVein[currentVein.Count - 1]);
            currentVein.RemoveAt(currentVein.Count-1);
        }
        return lootFound;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        popupText.SetActive(true);
        inMineZone = true;
        if (!isMineable)
        {
            popupText.GetComponent<TextMeshProUGUI>().text = "Can't mine this just yet.";
        }
        else
        {
            popupText.GetComponent<TextMeshProUGUI>().text = "Press [Q] to mine.";
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inMineZone = false;
        popupText.SetActive(false);
    }

    void RandomFill()
    {
        int veinAmount = Random.Range(64 / PlayerPrefs.GetInt(PrefNames.difficulty),
                                      128 / PlayerPrefs.GetInt(PrefNames.difficulty));
        for (int i = 0; i < veinAmount; i++)
        {
            currentVein.Add(RandomLoot());
        }
        isMineable = true;
    }

    int RandomLoot()
    {
        return Random.Range(0, lt.weightedLootItems.Count);
    }

    IEnumerator MineCoolDown()
    {
        yield return new WaitForSeconds(Random.Range(30*PlayerPrefs.GetInt(PrefNames.difficulty),
                                                     60 * PlayerPrefs.GetInt(PrefNames.difficulty)));
        RandomFill();
    }
}
