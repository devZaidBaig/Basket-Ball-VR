using UnityEngine;
using UnityEngine.VR;
using System.Collections;

///<summary>
///This class gets gyro data from the phone and applys them to VR Camera.
///The script must be attached to the Camera component in order to update properly
///</summary>
public class MonoView : MonoBehaviour
{
    /*
    public ButtonHandler buttonHandler;
    public GameObject EditorEmulator;
    private GvrEditorEmulator gvrEE;

    // Use this for initialization
    void Start()
    {
        EditorEmulator = GameObject.Find("GvrEditorEmulator");
        gvrEE = EditorEmulator.GetComponent<GvrEditorEmulator>();
        buttonHandler = GameObject.FindGameObjectWithTag("Button").GetComponent<ButtonHandler>();

        if (buttonHandler.EnableVR == false)
        {
            DisableVRSettings();
            Input.gyro.enabled = true; //activate the gyro on the phone
        }
        else
        {
            StartCoroutine(LoadDevice("cardboard"));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (buttonHandler.EnableVR == false)
        {
            Quaternion att = Input.gyro.attitude; //get the gyro data
            att = Quaternion.Euler(0f, 0f, 0f) * new Quaternion(att.x, att.y, -att.z, -att.w); //reorient the gyro data with the display
            transform.rotation = att; //assign the new rotation to the camera
        }
    }

    public void EnableVRMode()
    {
        if (VRSettings.enabled)
        {
            DisableVRSettings();
        }
        else
        {
            StartCoroutine(LoadDevice("cardboard"));
        }
    }

    private void EnableVRCamera()
    {
        gvrEE.enabled = true;
    }

    void DisableVRSettings()
    {
        VRSettings.enabled = false;
        VRSettings.LoadDeviceByName("None");
        buttonHandler.EnableVR = false;
        gvrEE.enabled = false;
    }

    IEnumerator LoadDevice(string newDevice)
    {
        VRSettings.LoadDeviceByName(newDevice);
        yield return null;
        VRSettings.enabled = true;
        buttonHandler.EnableVR = true;
        EnableVRCamera();
    }
    */
}

