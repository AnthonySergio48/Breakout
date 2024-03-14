using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{
    public static GameManager i;
    [SerializeField] bool levelPassed;
    [SerializeField] bool gameOver;
    [SerializeField] int numberOfBricks;
    [SerializeField] int numberOfLives;
    [SerializeField] int currentScore;
    [SerializeField] int currentLevel;

    [SerializeField] TMP_Text livesText;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] Transform gameOverPanel;
    [SerializeField] Transform LoadLevelPanel;

    [SerializeField] Ball mainBall;
    [SerializeField] List<GameObject> allLevels;
    [SerializeField] GameObject[] allBricks;
    [SerializeField] GameObject currentLevelObject;

    public bool LevelPassed()
    {
        return levelPassed;
    }
    
    
    
    private void Awake()
    {
        if (i == null)
        {
            i = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        LoadLevel();
        livesText.text = "Lives: " + numberOfLives;
        scoreText.text = "Score: " + currentScore;

    }

    void CountInitialBricks()
    {
        allBricks = GameObject.FindGameObjectsWithTag("Brick");
        for(int i = 0; i < allBricks.Length; i++)
        {  
            var infiniteBrick = allBricks[i].GetComponent<InfiniteBrick>();

            if(!infiniteBrick)
            {
                numberOfBricks++;
            }
           
        }
    }

    public void UpdateNumberOfBricks()
    {
        numberOfBricks--;
        if (numberOfBricks == 0)
        {
            //level passed
            LevelCleared();

            if (currentLevel < allLevels.Count)
            {
                Invoke("LoadLevel", 3f);
            }
            else
            {
                //GAME OVER
            }
        }
    }

    private void LoadLevel()
    {
        print("sgr");
        currentLevelObject = Instantiate(allLevels[currentLevel], Vector2.zero, Quaternion.identity);
        levelPassed = false;
        LoadLevelPanel.gameObject.SetActive(false);
        CountInitialBricks();
    }

    private void LevelCleared()
    {
        CleanupLevel();
        levelPassed = true;
        currentLevel++;
        LoadLevelPanel.gameObject.SetActive(true);
        LoadLevelPanel.GetComponentInChildren<TMP_Text>().text = "Load Level " + (currentLevel + 1);
       
    }
    void CleanupLevel()
    {
        currentLevelObject.SetActive(false);
    }

    public void UpdateNumberOfLives(int value = -1)
    {
  
        numberOfLives += value;
        livesText.text = "Lives: " + numberOfLives;

        if(numberOfLives == 0)
        {
            //game over
            GameOver();
        }
    }

    public void UpdateScore(int value)
    {
        currentScore += value;
        scoreText.text = "Score: " + currentScore;
    }
    void GameOver()
    {
        gameOver = true;
        gameOverPanel.gameObject.SetActive(true);



    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene("GameScene");
    }
}