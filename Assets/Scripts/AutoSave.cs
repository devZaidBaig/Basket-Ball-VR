using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AutoSave : MonoBehaviour {

    public ScoreCard ScoreCard;

    private void OnEnable()
    {
        saveScore();
    }

    public void saveScore()
    {
        PlayerPrefs.SetInt("HighScore", ScoreCard.score);

        if (PlayerPrefs.GetInt("SavedScore") < PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("SavedScore", PlayerPrefs.GetInt("HighScore"));
        }
    }
}
