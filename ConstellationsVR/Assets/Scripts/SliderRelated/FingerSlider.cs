//Part of ConstellationsVR
//
//This script goes on the SliderHitArea, checks for collisions with the pointer,
//and updates the position of the marker and slider value (output) accordingly

//???-->Aubrey at followspotfour@gmail.com
//Last edited Dec 2022

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FingerSlider : MonoBehaviour
{
    public GameObject marker;
    public CreatePointer rightHand, leftHand;//so that we can find the pointers
    public GameObject rightPointer; //tiny cube on the pointer finger
    public GameObject leftPointer; //tiny cube on the pointer finger
    private float output;
    private bool sliderIsTouchedRight, sliderIsTouchedLeft;//we need to know what hand we're using to know where to put the marker



    // Start is called before the first frame update
    void Start()
    {
        output = 0.0f;
    }

    //if someone tries really hard to break this by poking the slider with both hands at the same time, they can
    //we should maybe fix that later
    void OnTriggerEnter(Collider other){
      if (other.gameObject == rightPointer){
        sliderIsTouchedRight = true;
      }
      if (other.gameObject == leftPointer){
        sliderIsTouchedLeft = true;
      }
    }

    void OnTriggerExit(Collider other){
      if (other.gameObject == rightPointer){
        sliderIsTouchedRight = false;
      }
      if (other.gameObject == leftPointer){
        sliderIsTouchedLeft = false;
      }
    }

    public void FindPointers(){
      //this can't just happen in start because we need to make sure that
      //create pointer has actually created the pointer by the time we look for it
      //pointer = GameObject.Find("Pointer(Clone)");
      rightPointer = rightHand.pointer;
      leftPointer = leftHand.pointer;
    }

    //call this whenever a Csound object is selected
    public void SetMarkerAndOutputToValue(float newValue){
      output = newValue;

      float markerX = marker.transform.position.x;
      float markerZ = marker.transform.position.z;
      //if this is behaving weirdly, try switching to +0.5f or 1f-- it could be backwards
      marker.transform.localPosition = new Vector3(markerX, newValue - 0.5f, markerZ);
    }

    public float GetSliderValue(){
      return output;
    }

    void Update(){
      if(sliderIsTouchedRight || sliderIsTouchedLeft){
        float markerX = marker.transform.position.x;
        float markerZ = marker.transform.position.z;
        //marker.transform.position = hit.point;
        if(sliderIsTouchedRight){
          marker.transform.position = new Vector3(markerX, rightPointer.transform.position.y, markerZ);
        }
        if(sliderIsTouchedLeft){
          marker.transform.position = new Vector3(markerX, leftPointer.transform.position.y, markerZ);
        }
        output = marker.transform.localPosition.y + 0.5f;//makes it 0-1
        //we do this because the range is almost but not quite exact
        if(output < 0f){
          output = 0f;
        }
        else if(output>1f){
          output=1f;
        }
      }
    }
}//end class
