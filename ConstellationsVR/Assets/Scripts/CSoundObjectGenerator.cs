//Part of ConstellationsVR
//
//This script goes on the CSoundObject Prefab
//It lets us do things we'd like to have happen when the CSoundObject is selected/deselected by the Bird,
//using Bird's Unity Events

//???-->Aubrey at followspotfour@gmail.com
//Last edited Dec 2022

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSoundObjectGenerator : MonoBehaviour
{
    public GameObject cSoundPrefab;
    public GameObject currentSphere;

    private void OnTriggerExit(Collider other){
      if(other.gameObject == currentSphere){
        currentSphere = Instantiate(cSoundPrefab);
      }
    }

}
