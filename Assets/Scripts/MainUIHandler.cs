using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainUIHandler : MonoBehaviour
{
    
    // used on the menu button on click event
    public void BackToMenu ()
    {
        SceneManager.LoadScene(0);
    }
}
