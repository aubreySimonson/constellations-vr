//Part of ConstellationsVR
//
//This script generates an object at runtime called "pointer"
//which goes on the pointer finger, to make it easier to interact
//
//Right now it's set up to work for one hand-- some minor modifications could make it work for both
//with our interfaces

//???-->Aubrey at followspotfour@gmail.com
//Last edited Dec 2022
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatePointer : MonoBehaviour
{
    public GameObject pointer; //whatever you want to use to paint
    public GameObject pointerPrefab;
    public GameObject hand;//should be a gameobject with OVRSkeleton on it
    OVRSkeleton skeleton;
    OVRBone indexBone;
    public List<FingerSlider> fingerSliders;

    // We have to call this in a start function because in awake,
    //the skeleton hasn't been generated yet
    void Start()
    {
      skeleton = hand.GetComponent<OVRSkeleton>();
      pointer = Instantiate(pointerPrefab);
      foreach (OVRBone bone in skeleton.Bones)
      {
        if (bone.Id == OVRSkeleton.BoneId.Hand_Index3)
        {
          indexBone = bone;
          pointer.transform.position = bone.Transform.position;
          pointer.transform.SetParent(bone.Transform, true);
        }//end if
      }//end foreach
      //now we tell every finger slider about the pointer, after generating it
      foreach(FingerSlider slider in fingerSliders){
        slider.FindPointer();
      }
    }//end awake
}//end class
