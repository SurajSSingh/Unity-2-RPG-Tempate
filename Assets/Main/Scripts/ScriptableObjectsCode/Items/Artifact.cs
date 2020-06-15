using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Artifact", menuName = "CustomObject/Item/Artifact")]
public class Artifact : Item
{
    readonly public ItemType itemType = ItemType.Artifact;
}
