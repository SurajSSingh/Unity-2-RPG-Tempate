using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : ScriptableObject
{
    public enum ItemType { Ore, Artifact, ArtWork, Misc};

    public string itemName;
    public int price;
    public ItemType itemType;
    public Sprite sprite;
    public Color color = Color.white;
    public float rarity = 1.0f;
}
