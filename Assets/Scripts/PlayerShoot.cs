using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour {

    public new Camera camera;
    public float force = 10f;
    public float distance = 0.8f;
    public bool PlayerHolding = true;
    public GameObject transported;
    public Slider slider;

    private GameObject powerSlider;
    private float currentPower;
    private float defaultPower = 15f;
    private Touch touch;
    private bool direction = true;


    // Update is called once per frame
    void FixedUpdate () {

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

            if (Input.GetKeyDown(KeyCode.Joystick1Button0))
            {
                currentPower = slider.minValue;
            }
            else if (Input.GetKey(KeyCode.Joystick1Button0))
            {
                currentPower += (Time.deltaTime * defaultPower);
                slider.value = currentPower;
            }
            else if (Input.GetKeyUp(KeyCode.Joystick1Button0))
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
                foreach (Touch touch in Input.touches)
                {
                    if (PlayerHolding)
                    {
                        switch (touch.phase)
                        {
                            case TouchPhase.Began:
                                currentPower = slider.minValue;
                                break;
                            case TouchPhase.Stationary:
                                currentPower += (Time.deltaTime * defaultPower);
                                slider.value = currentPower;
                                break;
                            case TouchPhase.Moved:
                                currentPower += (Time.deltaTime * defaultPower);
                                slider.value = currentPower;
                                break;
                            case TouchPhase.Ended:
                                transported.GetComponent<Rigidbody>().useGravity = true;
                                transported.GetComponent<Rigidbody>().AddForce(camera.transform.forward * slider.value);
                                transported.GetComponent<Rigidbody>().transform.parent = GameObject.Find("Music").transform;
                                slider.value = slider.minValue;

                                PlayerHolding = false;
                                break;
                        }
                    }
                }
            }

        }
        else
        {
            if(direction && PlayerHolding)
            {
                slider.value += Time.deltaTime * defaultPower;
            }
            else
            {
                slider.value -= Time.deltaTime * defaultPower;
            }

            if(slider.value == slider.maxValue)
            {
                direction = false;
            }
            if(slider.value == slider.minValue)
            {
                direction = true;
            }

            if (Input.GetKey(KeyCode.Escape) && PlayerHolding)
            {
                Debug.Log("Space function called...");
                transported.GetComponent<Rigidbody>().useGravity = true;
                transported.GetComponent<Rigidbody>().AddForce(camera.transform.forward * slider.value);
                transported.GetComponent<Rigidbody>().transform.parent = GameObject.Find("Music").transform;
                slider.value = slider.minValue;

                PlayerHolding = false;
            }

            /*
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
            */
        }
    }
}
