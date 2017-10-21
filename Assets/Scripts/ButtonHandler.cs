using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class ButtonHandler : MonoBehaviour {

    public bool EnableVR = false;
    public bool activateTimer = false;
    public float timeLeft = 60f;
    private GameObject handlerDestroy;

    public void ChangeToPlay(string SceneToPlay)
    {
        if (this.gameObject != null)
        {
            SceneManager.LoadSceneAsync(SceneToPlay);
            activateTimer = true;
            if (SceneToPlay == "MenuScene")
            {
                handlerDestroy = GameObject.FindGameObjectWithTag("BallHolder");
                handlerDestroy.GetComponent<GetBall>().ChangeTagName();
            }
        }
    }

    public void RetryPlay()
    {
        activateTimer = true;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    void Start()
    {
            DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Joystick1Button1))
            Input.GetTouch(1);
    }
}
