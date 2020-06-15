using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootTable : MonoBehaviour
{
    public List<Item> lootItems;

    [SerializeField]
    public List<Item> weightedLootItems;
    // Start is called before the first frame update
    void Awake()
    {
        foreach (Item loot in lootItems)
        {
            for (int i = 0; i < (int)loot.rarity; i++)
            {
                weightedLootItems.Add(loot);
            }
        }
    }
}
