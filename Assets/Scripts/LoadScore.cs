using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;

public class LoadScore : MonoBehaviour {

    public TextMeshProUGUI scoreDisplay;
    private int tempHighScore;

    void Start()
    {
        if(PlayerPrefs.GetInt("SavedScore") < PlayerPrefs.GetInt("HighScore"))
        {
            tempHighScore = PlayerPrefs.GetInt("HighScore");
            PlayerPrefs.SetInt("SavedScore", tempHighScore);
        }
        scoreDisplay.text = PlayerPrefs.GetInt("SavedScore").ToString();
        Debug.Log("Score is loaded" + PlayerPrefs.GetInt("SavedScore"));
    }
}