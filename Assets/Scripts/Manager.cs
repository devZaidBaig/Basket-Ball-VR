using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public GameObject CanvasMenu;
    public GameObject GameOverCanvas;
    public GameObject[] GameObjectToBeActivated;
    public GetBall getBall;
    public ScoreCard scoreCard;
    public List<GameObject> InstructionButtons = new List<GameObject>();
    public List<GameObject> MainMenuButtons = new List<GameObject>();
    public List<GameObject> NextInstruction = new List<GameObject>();


    public void ChangeToPlay()
    {
        RetryCall();
        CanvasMenu.SetActive(false);
    }

    public void ReturnToMenu()
    {
        for (int i = 0; i < InstructionButtons.Count; i++)
        {
            InstructionButtons[i].SetActive(false);
        }

        for (int i = 0; i < NextInstruction.Count; i++)
        {
            NextInstruction[i].SetActive(false);
        }

        for (int j = 0; j < MainMenuButtons.Count; j++)
        {
            MainMenuButtons[j].SetActive(true);
        }
    }

    public void GoNext()
    {
        for (int j = 0; j < InstructionButtons.Count; j++)
        {
            InstructionButtons[j].SetActive(false);
        }

        for (int i = 0; i < NextInstruction.Count; i++)
        {
            NextInstruction[i].SetActive(true);
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    private void Start()
    {
       GameObjectToBeActivated[1].SetActive(false);
    }

    void Update()
    {
        if (getBall.NoOfTries == 0)
        {
            for (int i = 0; i < GameObjectToBeActivated.Length; i++)
            {
                GameObjectToBeActivated[i].SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < GameObjectToBeActivated.Length; i++)
            {
                GameObjectToBeActivated[i].SetActive(false);
            }
        }
    }

    public void ActivateCanvasMenu()
    {
        GameOverCanvas.SetActive(false);
        CanvasMenu.SetActive(true);
    }

    public void RetryCall()
    {
        getBall.NoOfTries = 11;
        scoreCard.score = 0;
        scoreCard.countText.text = 0 + "";
    }
}