using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseManager : MonoBehaviour
{
    // Player Infromation
    public int playerHealth;
    public int playerExp;
    public int playerGold;
    public List<Item> playerInventory;

    // Enemy Infromation
    public int enemyRemaining;
    public List<Enemy> enemyTypes;

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void SaveGame()
    {

    }

    public void LoadGame()
    {

    }
}
