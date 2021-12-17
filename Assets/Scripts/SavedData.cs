using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// Although you are saving "HighScoreEntry" instances,  they are on a list 
// called highScoreEntryList on Class "GamaData". That list gets transfered
// to this class (Vice Versa) via a method on GameData called "SaveGameData()"
// Please refer to GamaData for more details

[System.Serializable]
public class SavedData 
{
    public List<HighScoreEntry> myList = new List<HighScoreEntry>();
}
