//Put this on an object with a collider to make it move only on the Y axis when bird is through it
//Useful for making scroll-y lists
//Part of ConstellationsVR
//???--> Aubrey (asimonso@mit.edu)
//last edited November 2022

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListScroll : MonoBehaviour
{
    public Bird bird;
    Collider thisCollider;//collider component of the object this script is on
    private bool inCollider = false;
    private float yPos;//y position when bird enters object-- prevents snapping to the middle of the list

    // Start is called before the first frame update
    void Start()
    {
      if(bird == null){
        bird = GameObject.Find("OVRHandPrefab_Right").GetComponent<Bird>();
      }
      thisCollider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
      if(bird.birdRayHit.collider != null && bird.birdRayHit.collider == thisCollider){
        //we want to be sure to update yPos once, when the bird enters the collider,
        //rather than every frame, so that we don't just move it vertically by
        //birdPosition.y meters per frame
        if(!inCollider){
          yPos = bird.birdPosition.y;
          inCollider = true;
        }//end if
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, bird.birdPosition.y - yPos, gameObject.transform.position.z);
      }//end if
      else{
        if(inCollider){
          inCollider=false;
        }//end if
      }//end else
    }//end update
}
