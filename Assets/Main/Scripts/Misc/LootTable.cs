using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootTable : MonoBehaviour
{
    public List<Item> lootItems;
    public List<Item> weightedLootItems;

    [SerializeField]
    private List<int> transferance; // map from weighted to original

    // Start is called before the first frame update
    void Awake()
    {
        int curr = 0;
        foreach (Item loot in lootItems)
        {
            for (int i = 0; i < (int)loot.rarity; i++)
            {
                curr++;
                weightedLootItems.Add(loot);
            }
            transferance.Add(curr);
        }
    }

    public int ToSimpleInventory(int value)
    {
        for (int i = 0; i < transferance.Count;i++)
        {
            if (value <= transferance[i])
            {
                return i;
            }
        }
        return 0;
    }
}
