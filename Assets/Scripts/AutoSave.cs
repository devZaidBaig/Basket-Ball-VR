using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;

public class AutoSave : MonoBehaviour {

    public ScoreCard ScoreCard;

    private void OnEnable()
    {
        saveScore();
    }

    public void saveScore()
    {
        BinaryFormatter br = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/playerinfo.sav", FileMode.Create);

        PlayerScore data = new PlayerScore();
        data.saveScore = ScoreCard.score;

        br.Serialize(file, data);
        file.Close();

        Debug.Log("Score is Saved");
    }
}

[Serializable]
class PlayerScore
{
    public int saveScore;
}
