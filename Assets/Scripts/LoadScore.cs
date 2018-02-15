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
        if (PlayerPrefs.GetInt("SavedScore").ToString() == null)
        {
            scoreDisplay.text = "0";
        }
        else
        {
            scoreDisplay.text = PlayerPrefs.GetInt("SavedScore").ToString();
        }
    }
}