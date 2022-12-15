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

public class CSoundOnClickBehavior : MonoBehaviour
{
    public ObjectManager objectManager;
    public cuSliders sliders;
    // Start is called before the first frame update
    void Start()
    {
      if(objectManager == null){
        objectManager = GameObject.Find("Object Manager").GetComponent<ObjectManager>();
      }
      if(sliders == null){
        sliders = GameObject.Find("Sliders").GetComponent<cuSliders>();
      }
    }

    // Update is called once per frame
    public void DoTheseOnSelect()
    {
      objectManager.currentCsoundObject = gameObject;//tell object manager we selected this object
      //sliders.CsoundInstanceEditing();
      sliders.UpdatePositionofSliders(objectManager.currentCsoundObject);
    }

    public void DoTheseOnDeselect(){
      if(objectManager.currentCsoundObject == gameObject){
        sliders.SavePreset();
        objectManager.currentCsoundObject = null;//tell the object manager we no longer have anything selected
      }
    }
}
