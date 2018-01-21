using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public Slider loadSlider;
    public TextMeshProUGUI loadText;
    public GameObject[] GameObjectToBeActivated;
    public GetBall getBall;


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

    public void ReturnToMenu(string SceneToPlay)
    {
        if (this.gameObject != null)
        {
            loadSlider.gameObject.SetActive(true);
            StartCoroutine(LoadAsyn(SceneToPlay));
        }
    }

    private IEnumerator LoadAsyn(string sceneToPlay)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneToPlay);
        loadSlider.gameObject.SetActive(true);

        while (!operation.isDone)
        {
            int progress = (int)Mathf.Clamp01(operation.progress / 0.9f);
            loadSlider.value = progress;

            loadText.text = progress * 100f + "%";
            yield return null;
        }
    }

    public void RetryCall()
    {
        Debug.Log("Retry Call");
    }
}