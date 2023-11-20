using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;

public class MenuScript : MonoBehaviour
{
    public TMP_Text BestScore;

    public void Awake()
    {
        if (PlayerPrefs.HasKey("bestScore"))
        {
            var bestScore = PlayerPrefs.GetInt("bestScore");
            BestScore.text = "Best score: " + bestScore;
        }
    }
    
    public void StartGame()
    {
        Debug.Log("Game start selected");
        SceneManager.LoadScene("Scenes/GameScene");
    }
    public void QuitGame()
    {
        Debug.Log("Quit game selected");
        Application.Quit();
    }
}
