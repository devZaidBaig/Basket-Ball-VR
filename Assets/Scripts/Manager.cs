using System.Collections.Generic;
using UnityEngine;
public class Manager : MonoBehaviour
{
    public GameObject CanvasMenu;
    public GameObject GameOverCanvas;
    public GameObject GvrRecticlePointer;
    public GameObject respawnPoint;
    public ScoreCard scoreCard;
    public GameObject slider;
    public List<GameObject> InstructionButtons = new List<GameObject>();
    public List<GameObject> MainMenuButtons = new List<GameObject>();
    public List<GameObject> NextInstruction = new List<GameObject>();
    public Transform StartPosition;

    private bool Playing = false;
    private bool MenuPositionChange = false;
    private GameObject Player;
    private float speed = 1f;

    private void Start()
    {
        Player = GameObject.Find("Player");
    }

    public void ChangeToPlay()
    {
        RetryCall();
        respawnPoint.SetActive(true);
        respawnPoint.GetComponent<GetBall>().CreateBall();
        CanvasMenu.SetActive(false);
        Playing = true;
        slider.SetActive(true);
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

    public void InstructionCall()
    {
        for (int j = 0; j < MainMenuButtons.Count; j++)
        {
            MainMenuButtons[j].SetActive(false);
        }

        for (int i = 0; i < InstructionButtons.Count; i++)
        {
            InstructionButtons[i].SetActive(true);
        }
    }

    public void GoNextInstruction()
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

    void Update()
    {
        if (!Playing)
        {
            GvrRecticlePointer.SetActive(true);
        }
        else
        {
            GvrRecticlePointer.SetActive(false);
        }

        if(respawnPoint.GetComponent<GetBall>().NoOfTries == 0 && Playing)
        {
            GameOverCanvas.SetActive(true);
            Playing = false;
        }

        if (MenuPositionChange)
        {
            float step = speed * Time.deltaTime;
            Player.transform.position = Vector3.MoveTowards(Player.transform.position, StartPosition.transform.position, step);
            MenuPositionChange = false;
        }
    }

    public void ActivateCanvasMenu()
    {
        GameOverCanvas.SetActive(false);
        CanvasMenu.SetActive(true);
        MenuPositionChange = true;
    }

    public void RetryCall()
    {
        respawnPoint.GetComponent<GetBall>().NoOfTries = 11;
        scoreCard.score = 0;
        scoreCard.countText.text = 0 + "";
        Playing = true;
    }
}