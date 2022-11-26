//Put this on each list item.
//Communicates with ListScroll to make scroll-y lists
//
//Part of ConstellationsVR
//???--> Aubrey (asimonso@mit.edu)
//last edited November 2022

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ListItem : MonoBehaviour
{
    public ListScroll listScroll;
    public Bird bird;
    Collider thisCollider;//collider component of the object this script is on
    private bool inCollider = false;

    [SerializeField] UnityEvent OnTouch;
    [SerializeField] UnityEvent OnRelease;

    // Start is called before the first frame update
    void Start()
    {
      if(bird == null){
        bird = GameObject.Find("OVRHandPrefab_Right").GetComponent<Bird>();
      }
      thisCollider = GetComponent<Collider>();
    }

    private void startScroll(){
      listScroll.scrolling = true;
      OnTouch.Invoke();
    }

    private void stopScroll(){
      listScroll.scrolling = false;
      OnRelease.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
      if(bird.birdRayHit.collider != null && bird.birdRayHit.collider == thisCollider){
        inCollider = true;
        startScroll();
      }//end if
      else{
        if(inCollider){
          inCollider = false;
          stopScroll();
        }//end if
      }//end else
    }//end update
}
