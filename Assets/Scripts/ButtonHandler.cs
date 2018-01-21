using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using TMPro;

public class ButtonHandler : MonoBehaviour {

    public GameObject loadScreen;
    public Slider loadSlider;
    public TextMeshProUGUI loadText;
    public List<GameObject> InstructionButtons = new List<GameObject>();
    public List<GameObject> MainMenuButtons = new List<GameObject>();
    public List<GameObject> NextInstruction = new List<GameObject>();

    public void ChangeToPlay(string SceneToPlay)
    {

        if (this.gameObject != null)
        {
            Debug.Log("Hello");
            loadScreen.SetActive(true);
            StartCoroutine(LoadAsyn(SceneToPlay));
        }
    }

    private IEnumerator LoadAsyn(string sceneToPlay)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneToPlay);
        loadScreen.SetActive(true);

        while (!operation.isDone)
        {
            int progress = (int) Mathf.Clamp01(operation.progress/0.9f);
            loadSlider.value = progress;

            loadText.text = progress * 100f + "%";
            yield return null;
        }
    }

    public void InstructionClick()
    {
        for (int i = 0; i < InstructionButtons.Count; i++)
        {
            InstructionButtons[i].SetActive(true);
        }

        for (int j = 0; j < MainMenuButtons.Count; j++)
        {
            MainMenuButtons[j].SetActive(false);
        }
    }

    public void ReturnToMenu()
    {
        for (int i = 0; i < InstructionButtons.Count; i++)
        {
            InstructionButtons[i].SetActive(false);
        }

        for (int j = 0; j < MainMenuButtons.Count; j++)
        {
            MainMenuButtons[j].SetActive(true);
        }
    }

    public void GoNext()
    {
        Debug.Log("Next Page of Instruction");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
