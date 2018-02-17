using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GetBall : MonoBehaviour {

    public PlayerShoot player;
    public GameObject BallPrefab;
    public GameObject transport;
    public GameObject TimeObject;
    public int NoOfTries = 10;
    public TextMeshProUGUI TryCount;

    private GameObject ReferenceForDestroy;
    private int time;
    private float TimeToCreateBall = 3f;


    
    void Update()
    {
        
        //Checking if the canvas is instantiated or not
        if (NoOfTries != 0)
        {
            //Check if Player is holding or not
            if (player.PlayerHolding == false)
            {
                TimeToCreateBall -= Time.deltaTime;

                //Recreate a ball after throw
                if (TimeToCreateBall <= 0)
                {
                    NoOfTries--;
                    TryCount.text = NoOfTries + "";
                    player.PlayerHolding = true;

                    //Destroy The thrown ball
                    Destroy(transport);

                    //Recreate ball with a reference
                    ReferenceForDestroy = Instantiate(BallPrefab, transform.position, Quaternion.identity);
                    ReferenceForDestroy.transform.parent = GameObject.Find("Main Camera").transform;
                    player = ReferenceForDestroy.GetComponent<PlayerShoot>();

                    //Reset the time and original = reference
                    TimeToCreateBall = 3f;
                    transport = ReferenceForDestroy;
                }
            }
        }
        else
        {
            Destroy(transport);
            player.PlayerHolding = false;
        }
}

    //Meathod to create ball once the scene is created
    public void CreateBall()
    {
        TryCount.text = NoOfTries + "";
        transport = Instantiate(BallPrefab, transform.position, Quaternion.identity);
        transport.transform.parent = GameObject.Find("Main Camera").transform;
        player = transport.GetComponent<PlayerShoot>();
        TimeObject = GameObject.FindGameObjectWithTag("Button");
    }
}
