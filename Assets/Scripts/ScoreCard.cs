using UnityEngine;
using UnityEngine.UI;
using System;


public class ScoreCard : MonoBehaviour {

    public Text countText;
    public int score = 0;
    public GameObject movePlayer;

    private Vector3 randomPosition;

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            score++;
            countText.text = score.ToString();
        }

        if(score > 0)
        {
            randomPosition = new Vector3(UnityEngine.Random.Range(2,-3),1.84f, UnityEngine.Random.Range(-0.5f,-1.5f));
            movePlayer.transform.position = Vector3.Lerp(movePlayer.transform.position, randomPosition, 1f);
        }
    }

}