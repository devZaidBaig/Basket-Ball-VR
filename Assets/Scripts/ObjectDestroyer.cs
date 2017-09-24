using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour {

    private GameObject ObjectToDestroy;
	// Use this for initialization
	void Start () {
        ObjectToDestroy = GameObject.FindGameObjectWithTag("UsedObject");
        Destroy(ObjectToDestroy);
    }

}
