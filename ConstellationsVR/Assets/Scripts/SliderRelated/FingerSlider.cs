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
    public GameObject pointer; //tiny cube on the pointer finger
    private float output;
    private bool sliderIsTouched;
    public Text debugText;
    public Text debugText2;
    public Text debugText3;


    // Start is called before the first frame update
    void Start()
    {
        output = 0.0f;
    }

    void OnTriggerEnter(Collider other){
      if (other.gameObject == pointer){
        sliderIsTouched = true;
        debugText2.text = "true";
      }
    }

    void OnTriggerExit(Collider other){
      if(other.gameObject == pointer){
        sliderIsTouched = false;
        debugText2.text = "false";
      }
    }

    public void FindPointer(){
      debugText.text = "find pointer called";
      //this can't just happen in start because we need to make sure that
      //create pointer has actually created the pointer by the time we look for it
      pointer = GameObject.Find("Pointer(Clone)");
      if(pointer!=null){
        debugText.text = "pointer found";
      }
    }

    void Update(){
      if(sliderIsTouched){
        float markerX = marker.transform.position.x;
        float markerY = marker.transform.position.y;
        float markerZ = marker.transform.position.z;
        //marker.transform.position = hit.point;
        marker.transform.position = new Vector3(markerX, pointer.transform.position.y, markerZ);
        output = marker.transform.localPosition.y + 0.5f;//makes it 0-1
        //we do this because the range is almost but not quite exact
        if(output < 0f){
          output = 0f;
        }
        else if(output>1f){
          output=1f;
        }
        debugText3.text = output.ToString();
      }
    }

    // void Update()
    // {
    //     debugText2.text = indexBone.Transform.position.ToString();
    //     RaycastHit hit;
    //     if (Physics.Raycast(pointer.transform.position, pointer.transform.up, out hit, 100.0f))//we've tried forward
    //     {
    //         if(hit.collider.gameObject.name == "SliderHitArea")
    //         {
    //             //you need to convert everything to local coordinates so that it has the right axis and everything
    //             Vector3 localHit = transform.InverseTransformPoint(hit.point);
    //             float markerX = marker.transform.localPosition.x;
    //             float markerY = marker.transform.localPosition.y;
    //             float markerZ = marker.transform.localPosition.z;
    //             //marker.transform.position = hit.point;
    //             marker.transform.localPosition = new Vector3(markerX, localHit.y, markerZ);
    //             debugText4.text = localHit.y.ToString();
    //             output = localHit.y + 0.5f * 10.0f;//makes it 0-1
    //             debugText.text = output.ToString();
    //         }//end if
    //     }//end if
    // }//end update
}//end class
