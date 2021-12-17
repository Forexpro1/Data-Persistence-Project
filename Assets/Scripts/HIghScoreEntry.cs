using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class HighScoreEntry 
{
    public string playerName;
    public int score;
    
    public HighScoreEntry(string name, int pts)
    {
        playerName = name;
        score = pts;
    }
    public HighScoreEntry()
    {

    }
    
}
