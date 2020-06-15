using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : ScriptableObject
{
    public enum ItemType { Weapon, Potion, Coin, Default};

    public string itemName;
    public ItemType itemType;
    public Sprite sprite;

}
