using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour {
    public Camera camera;
    public float force = 10f;
    public float distance = 0.8f;
    public bool PlayerHolding = true;
    public GameObject transported;
    public GetBall getBall;
    public Slider slider;

    private GameObject powerSlider;
    private float currentPower;
    private float defaultPower = 15f;
    private Touch touch;


    // Update is called once per frame
    void Update () {

        powerSlider = GameObject.FindGameObjectWithTag("Slider");
        slider = powerSlider.GetComponent<Slider>();

        if(transported == null)
        {
            transported = GameObject.FindGameObjectWithTag("Player");
            transported.GetComponent<Rigidbody>().useGravity = false;
            camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        }
        if (Application.isMobilePlatform)
        {
            //Test in mobile & joystick combo.

            if (Input.GetKeyDown(KeyCode.Joystick1Button0) || touch.phase == TouchPhase.Began)
            {
                currentPower = slider.minValue;
            }
            else if (Input.GetKey(KeyCode.Joystick1Button0) || touch.phase == TouchPhase.Stationary)
            {
                currentPower += (Time.deltaTime * defaultPower);
                slider.value = currentPower;
            }
            else if (Input.GetKeyUp(KeyCode.Joystick1Button0) || touch.phase == TouchPhase.Ended)
            {
                transported.GetComponent<Rigidbody>().useGravity = true;
                transported.GetComponent<Rigidbody>().AddForce(camera.transform.forward * slider.value);
                transported.GetComponent<Rigidbody>().transform.parent = GameObject.Find("Music").transform;
                slider.value = slider.minValue;

                PlayerHolding = false;
            }

            //Touch hold powerup for ball shoot.
            if (Input.touchCount > 0)
            {
                var tapCount = Input.touchCount;
                for (var i = 0; tapCount > i; i++)
                {
                    if (i < 1)
                    {
                        touch = Input.GetTouch(i);
                    }
                    if (touch.phase == TouchPhase.Stationary)
                    {
                        currentPower += (Time.deltaTime * defaultPower);
                        slider.value = currentPower;
                    }
                }
            }

        }
        else
        { 
            //test in editor
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                currentPower = slider.minValue;
            }
            else if (Input.GetKey(KeyCode.Escape))
            {
                currentPower += (Time.deltaTime*defaultPower);
                slider.value = currentPower;
            }
            else if (Input.GetKeyUp(KeyCode.Escape))
            {
                Debug.Log("Space function called...");
                transported.GetComponent<Rigidbody>().useGravity = true;
                transported.GetComponent<Rigidbody>().AddForce(camera.transform.forward * slider.value);
                transported.GetComponent<Rigidbody>().transform.parent = GameObject.Find("Music").transform;
                slider.value = slider.minValue;

                PlayerHolding = false;
            }
        }
	}
}
