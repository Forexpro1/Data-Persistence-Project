using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public Brick BrickPrefab;
    public int LineCount = 6;
    public Rigidbody Ball;

    public GameObject GameOverTitle;
    public GameObject inputNameField;
    public Text ScoreText;
    public HighScore highScore;
    private int tempInt;
    public Paddle paddle;
    
    
    
    private bool m_Started = false;
    private int m_Points;
    
    private bool m_GameOver = false;

    
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
        
        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);
        
        int[] pointCountArray = new [] {1,1,2,2,5,5};
        for (int i = 0; i < LineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                brick.PointValue = pointCountArray[i];
                brick.onDestroyed.AddListener(AddPoint);
            }
        }
    }

    private void Update()
    {
        if (!m_Started)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_Started = true;
                float randomDirection = Random.Range(-1.0f, 1.0f);
                Vector3 forceDir = new Vector3(randomDirection, 1, 0);
                forceDir.Normalize();

                Ball.transform.SetParent(null);
                Ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
            }
        }
        else if (m_GameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    void AddPoint(int point)
    {
        m_Points += point;
        ScoreText.text = $"Score : {m_Points}";
    }

    public void GameOver()
    {
        m_GameOver = true;
        paddle.isMovementDisabled = true;
        GameOverTitle.SetActive(true);
        
        if (m_Points > GameData.highScoreEntryList[GameData.highScoreEntryList.Count-1].score )
        {
            
            inputNameField.SetActive(true);
            
        }
    }
    // used on the inputfield button when you push enter after name entry
    public void CollectInputFieldName()
    {
        InputField inputName = inputNameField.GetComponentInChildren<InputField>();
        inputNameField.SetActive(false);

        GameData.highScoreEntryList.RemoveAt(GameData.highScoreEntryList.Count-1);

        HighScoreEntry temp = new HighScoreEntry(inputName.text,m_Points);
        GameData.highScoreEntryList.Add(temp);

        highScore.SortList();

        highScore.LoadHighScores();

        GameData.SaveGameData();
        GameOverTitle.SetActive(false);
        
    }
    
}
