using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class GameData : MonoBehaviour
{
    // creating a Singleton for Data to persist during Scene Changes
    public static GameData Instance;
    public SavedData savedData;
    
    public static List<HighScoreEntry> highScoreEntryList;
    
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

    }


    // a new SavedData instance must be created called "data" for the list
    // items to work and transfer. "data" is the instance that officially writes
    // to a file called "savefile.json"
    public static void SaveGameData()
    {
        SavedData data = new SavedData();
        
        foreach (var entry in highScoreEntryList)
        {
            data.myList.Add(entry);
        }
        
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    // Vice Versa of the save data
    public static void LoadGameData()
    {

        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            highScoreEntryList = new List<HighScoreEntry>();
            string json = File.ReadAllText(path);
           
            SavedData data = JsonUtility.FromJson<SavedData>(json);
            foreach (var entry in data.myList)
            {
                highScoreEntryList.Add(entry);
            }
        }
    }
   
   
}
