using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{

    public HighScore highScore;

    // Start is called before the first frame update
    void Start()
    {

        GameData.LoadGameData();
        // if the game is played for first time, it will create a default list
        if (GameData.highScoreEntryList == null)
        {
            highScore.CreateDefaultList();
        }
        
        highScore.SortList();
        highScore.LoadHighScores();
        
    }

    

    // used to load scene again
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    // used on the exit button on click event
    public void ExitGame()
    {
#if UNITY_EDITOR

        GameData.SaveGameData();
        EditorApplication.ExitPlaymode();
        
#else
        GameData.SaveGameData();
        Application.Quit();
#endif

    }
}
