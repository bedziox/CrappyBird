using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    private int bestScore;
    public Text bestScoreText;
    public Text scoreText;
    public GameObject gameOverScreen;
    // Start is called before the first frame update
    [ContextMenu("Increase Score")]
    public void AddScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoreText.text =  "Score: " + playerScore;
    }
    public void RestartGame()
    {
        Debug.Log("Game restarted");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Debug.Log("Game quit");
        Application.Quit();
    }

    public void GameOver()
    {
        if(PlayerPrefs.HasKey("bestScore"))
        {
            if(playerScore > PlayerPrefs.GetInt("bestScore"))
            {
                bestScore = playerScore;
                PlayerPrefs.SetInt("bestScore", bestScore);
                PlayerPrefs.Save();
            }
        }
        else
        {   
            if(playerScore > bestScore)
            {
                bestScore = playerScore;
                PlayerPrefs.SetInt("bestScore", bestScore);
                PlayerPrefs.Save();
            }
        }
        bestScoreText.text = "Best score: " + bestScore;
        if(gameOverScreen)
            gameOverScreen.SetActive(true);
    }
}
