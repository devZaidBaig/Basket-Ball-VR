using UnityEngine;
using UnityEngine.UI;
using System;


public class ScoreCard : MonoBehaviour {

    public Text countText;
    public int score = 0;
    public GameObject movePlayer;
    public float speed = 1f;

    private Vector3 randomPosition;
    private bool scored = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            score++;
            scored = true;
            countText.text = score.ToString();
            randomPosition = new Vector3(UnityEngine.Random.Range(2, -3), 1.84f, UnityEngine.Random.Range(-0.5f, -1.5f));
        }
    }

    private void Update()
    {
        if(scored)
        {
            float step = speed * Time.deltaTime;
            movePlayer.transform.position = Vector3.MoveTowards(movePlayer.transform.position,randomPosition,step);
        }
    }

}