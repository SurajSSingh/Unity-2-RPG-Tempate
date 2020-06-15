using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "CustomObject/Enemy")]
public class Enemy : ScriptableObject
{
    public int health = 100;
    public int minDamage = 10;
    public int maxDamage = 10;

    public GameObject sprite;
    public Color color = Color.black;
}
