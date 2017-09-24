using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSound : MonoBehaviour {

    public AudioSource bounceSound;
    private void OnCollisionEnter(Collision collision)
    {
        bounceSound.Play();
    }
}
