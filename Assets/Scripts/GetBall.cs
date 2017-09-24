using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetBall : MonoBehaviour {

    public PlayerShoot player;
    private float TimeRemaining = 1f;
    public GameObject BallPrefab;
    public GameObject transport;
    private GameObject ReferenceForDestroy;
    public float timeLeft;
    public GameObject TimeObject;
    public Text text;
    private int time;
    public ActivateCanvas CheckTimeUp;
    public Text checkText;


	void Start () {
        CreateBall();
	}


    void Update()
    {
        if (Input.anyKey)
        {
            checkText.text = " " + (string)Input.inputString;
        }
        //Checking if the canvas is instantiated or not
        if (CheckTimeUp.TimeUp == false)
        {
            //Check if Player is holding or not
            if (player.PlayerHolding == false)
            {
                TimeRemaining -= Time.deltaTime;

                //Recreate a ball after throw
                if (TimeRemaining <= 0)
                {
                    player.PlayerHolding = true;

                    //Destroy The thrown ball
                    Destroy(transport);

                    //Recreate ball with a reference
                    ReferenceForDestroy = Instantiate(BallPrefab, transform.position, Quaternion.identity);
                    ReferenceForDestroy.transform.parent = GameObject.Find("Main Camera").transform;
                    player = ReferenceForDestroy.GetComponent<PlayerShoot>();

                    //Reset the time and original = reference
                    TimeRemaining = 3f;
                    transport = ReferenceForDestroy;
                }
            }
        }
        else
        {
            Destroy(transport);
            player.PlayerHolding = false;
        }

        TimeMeathod(); //Countdown Timer
}

    //Meathod to create ball once the scene is created
    void CreateBall()
    {
        transport = Instantiate(BallPrefab, transform.position, Quaternion.identity);
        transport.transform.parent = GameObject.Find("Main Camera").transform;
        player = transport.GetComponent<PlayerShoot>();
        TimeObject = GameObject.FindGameObjectWithTag("Button");
        timeLeft = TimeObject.GetComponent<ButtonHandler>().timeLeft;
    }

    //This is meathod is only for timer countdown
    void TimeMeathod()
    {
        if (TimeObject.GetComponent<ButtonHandler>().activateTimer == true)
        {
            timeLeft -= Time.deltaTime;
            time = (int)timeLeft;
            if (timeLeft > 0)
            {
                text.text = time.ToString();
            }
            else if (timeLeft <= 0)
            {
                TimeObject.GetComponent<ButtonHandler>().activateTimer = false;
                timeLeft = TimeObject.GetComponent<ButtonHandler>().timeLeft;
            }
        }
    }

    public void RetryCall()
    {
        TimeObject.GetComponent<ButtonHandler>().activateTimer = true;
        CreateBall();
    }

    public void ChangeTagName()
    {
        TimeObject.transform.gameObject.tag = "UsedObject";
    }
}
