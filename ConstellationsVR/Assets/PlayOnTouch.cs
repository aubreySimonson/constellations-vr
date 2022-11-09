//Part of ConstellationsVR, a VR adaptation of some of the basic ideas of
//Constellations, a project which was once part of the Opera of the Future Group at the MIT Media Lab.
//This version of the project isn't really the most scalable thing you've ever seen--
//It's more meant to be a demo/proof of concept.
//
//This particular script goes on sound spheres and controls their playing sounds when touched.
//???-->Aubrey at followspotfour@gmail.com
//Last edited Nov 2022

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOnTouch : MonoBehaviour
{
    private AudioSource audioSource;//one audio source on every game object
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        if(audioSource == null){
          Debug.Log("A sound sphere is lacking an audio source! That's not supposed to happen");
        }
    }

    void OnTriggerEnter(Collider other){
      if(other.gameObject.name == "BirdMarker2"){//fragile
        audioSource.Play();
      }
    }
}
