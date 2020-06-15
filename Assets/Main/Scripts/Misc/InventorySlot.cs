using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    public int indexItem;
    public int amount;
    public Item mainItem;
    public TextMeshProUGUI infoText;

    public void InitalizeSelf(int currentIndex, PlayerManager player)
    {
        indexItem = currentIndex;
        if (currentIndex < player.invetory.Count)
        {
            indexItem = currentIndex;
            amount = 0;
            mainItem = (Item) ScriptableObject.CreateInstance(player.lt.lootItems[indexItem].name);
        }
        else
        {
            indexItem = -1;
            amount = -1;
        }
    }

    public void UpdateSelf(PlayerManager player)
    {
        if (indexItem > -1)
        {
            amount = player.invetory[indexItem].itemAmount;
            GetComponentInChildren<Image>().sprite = player.lt.lootItems[indexItem].sprite;
            GetComponentInChildren<Image>().color = player.lt.lootItems[indexItem].color;
        }
        GetComponentInChildren<TextMeshProUGUI>().text = amount.ToString();
    }

    public void UpdateInfo()
    {
        infoText.text = "Name: " + mainItem.name +
                        "\nAmount: " + amount.ToString() +
                        "\nType: " + mainItem.itemType.ToString() +
                        "\nRarity: " + mainItem.rarity.ToString() + "%" +
                        "\nPrice Per: " + mainItem.price.ToString() +
                        "\nTotal Price: " + (mainItem.price*amount).ToString();
    }
}
