using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class inventorySlotProxy
{
    public int itemIndex;
    public int itemAmount;
}


public class PlayerManager : MonoBehaviour
{
    public int gold = 0;
    public int experience = 1;
    public TextMeshProUGUI goldText;
    public TextMeshProUGUI expText;
    public LootTable lt;
    public List<inventorySlotProxy> invetory = new List<inventorySlotProxy>();

    // Start is called before the first frame update
    void Start()
    {
        lt = GameObject.FindGameObjectWithTag("LootTable").GetComponent<LootTable>();
        for (int i = 0; i < lt.lootItems.Count; i++)
        {
            invetory.Add(new inventorySlotProxy { itemIndex = i, itemAmount = 0 });
        }
        UpdateUI();
    }

    void UpdateUI()
    {
        goldText.text = "Gold: " + gold.ToString();
        expText.text = "Exp: " + experience.ToString();
    }

    public int SellAll(Item.ItemType iType)
    {
        int amountMade = 0;
        for (int i = 0; i < invetory.Count; i++)
        {
            if(lt.lootItems[invetory[i].itemIndex].itemType == iType)
            {
                amountMade += lt.lootItems[invetory[i].itemIndex].price * invetory[i].itemAmount;
                invetory[i] = new inventorySlotProxy { itemIndex = i, itemAmount = 0 };
            }
            
        }
        gold += amountMade;
        UpdateUI();
        return amountMade;
    }

    public void AddToInventory(List<int> values)
    {
        
        foreach(int index in values)
        {
            invetory[lt.ToSimpleInventory(index)].itemAmount += 1;
        }
        float multipler = (float) PlayerPrefs.GetInt(PrefNames.difficulty);
        experience += Mathf.RoundToInt(Random.Range(1/multipler, multipler) *
                            (((float)values.Count)/multipler));
        UpdateUI();
    }
}
