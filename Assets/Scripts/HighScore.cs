using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HighScore : MonoBehaviour
{
    
    public GameObject mainPanel;
    public GameObject titleScreen;
    public  TextMeshProUGUI[] highScoreTextMesh;
   
    public void CreateDefaultList ()
    {
        //creating default list
        GameData.highScoreEntryList = new List<HighScoreEntry>()
        {
            new HighScoreEntry ("Forexpro", 95),
            new HighScoreEntry ("John", 14),
            new HighScoreEntry ("Rick", 3),
            new HighScoreEntry ("Mike", 82),
            new HighScoreEntry ("Max", 33),
            new HighScoreEntry ("Jackie", 67),
            new HighScoreEntry ("James", 75),
            new HighScoreEntry ("Anna", 41),
            new HighScoreEntry ("Luke", 51),
            new HighScoreEntry ("Yolo", 25),
        };

    }
    // used on HighScore Button On Click Event
    public void TurnOnHighScore()
    {
        mainPanel.SetActive(true);
        titleScreen.SetActive(false);
        
    }
    // used on Exit button on cLick event within HighScore Panel
    public void TurnOffHighScore()
    {
        mainPanel.SetActive(false);
        titleScreen.SetActive(true);
    }
   
    // sets the list "highScoreEntryList" onto the TextMeshpro.text display
    public void LoadHighScores()
    {
        for (int i = 0; i<GameData.highScoreEntryList.Count; i++)
        {
            highScoreTextMesh[i*2].text = GameData.highScoreEntryList[i].playerName;
            highScoreTextMesh[(i*2)+1].text = GameData.highScoreEntryList[i].score.ToString();
        }
           
    }
  //  algorithm for reorganizing "highScoreEntryList" based on score variable
    public void SortList ()
    {
        for (int i = 0; i < GameData.highScoreEntryList.Count; i++)
        {
            for (int j = i+1; j < GameData.highScoreEntryList.Count; j++)
            {
                if (GameData.highScoreEntryList[j].score >GameData.highScoreEntryList[i].score)
                {
                    HighScoreEntry tmp = GameData.highScoreEntryList[i];
                    GameData.highScoreEntryList[i] = GameData.highScoreEntryList[j];
                    GameData.highScoreEntryList[j] = tmp;
                }
            }
        }

    }

        

}
