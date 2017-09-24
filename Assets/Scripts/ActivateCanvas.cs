using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateCanvas : MonoBehaviour {

    public GetBall timeObject;
    public GameObject[] GameObjectToBeActivated;
    public bool TimeUp = false;
    private int count = 0;

    void Update () {
		if(timeObject.TimeObject.GetComponent<ButtonHandler>().activateTimer == false && count<=0)
        {
            for (int i = 0; i < GameObjectToBeActivated.Length; i++)
            {
                GameObjectToBeActivated[i].SetActive(true);
            }
            count++;
            TimeUp = true;
        } else if(timeObject.TimeObject.GetComponent<ButtonHandler>().activateTimer == true && count>=1) 
        {
            for (int i = 0; i < GameObjectToBeActivated.Length; i++)
            {
                GameObjectToBeActivated[i].SetActive(false);
            }
            count = 0;
            TimeUp = false;
        }
	}
}
