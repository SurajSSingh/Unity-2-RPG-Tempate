using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    private class SaveObject
    {
        public Vector3 Position;
        public int Gold;
        public int Experience;
        public int Difficulty;
        public string Name;
        public List<int> ItemAmounts;
    }

    public PlayerManager pm;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        SaveSystem.Init();
    }

    public void SaveGame()
    {
        pm = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
        SaveObject saveObj = new SaveObject
        {
            Position = pm.transform.position,
            Gold = pm.gold,
            Experience = pm.experience,
            Difficulty = PlayerPrefs.GetInt(PrefNames.difficulty),
            Name = PlayerPrefs.GetString(PrefNames.playerName),
            ItemAmounts = new List<int>(pm.invetory.Count)
        };
        foreach (inventorySlotProxy proxy in pm.invetory)
        {
            saveObj.ItemAmounts.Add(proxy.itemAmount);
        }
        string json = JsonUtility.ToJson(saveObj);
        SaveSystem.Save(json);
    }

    public void LoadGame()
    {
        SaveObject loadedSave = JsonUtility.FromJson<SaveObject>(SaveSystem.Load());
        PlayerPrefs.SetInt(PrefNames.difficulty, loadedSave.Difficulty);
        PlayerPrefs.SetString(PrefNames.playerName, loadedSave.Name);
        Debug.Log(loadedSave.Experience);
        StartCoroutine(LoadingValues(loadedSave));
    }

    IEnumerator LoadingValues(SaveObject loadedSave)
    {
        while (SceneManager.GetActiveScene().buildIndex != 1)
        {
            Debug.Log("Wait");
            yield return new WaitForSecondsRealtime(0.5f);
        }
        Debug.Log("Load Value");
        pm = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
        pm.gold = loadedSave.Gold;
        pm.experience = loadedSave.Experience;
        pm.gameObject.transform.position = loadedSave.Position;
        for (int i = 0; i < loadedSave.ItemAmounts.Count; i++)
        {
            pm.invetory[i].itemAmount = loadedSave.ItemAmounts[i];
        }
        pm.UpdateUI();
    }
}