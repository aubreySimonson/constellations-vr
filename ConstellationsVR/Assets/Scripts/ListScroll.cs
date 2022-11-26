//Works with ListItem to make a list that moves only on the Y axis when bird is through it
//Part of ConstellationsVR
//???--> Aubrey (asimonso@mit.edu)
//last edited November 2022

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListScroll : MonoBehaviour
{
    private float yPos;//y position when bird enters object-- prevents snapping to the middle of the list
    private float originalYPos;
    public bool scrolling;
    private bool inCollider;
    public Bird bird;

    // Start is called before the first frame update
    void Start()
    {
      if(bird == null){
        bird = GameObject.Find("OVRHandPrefab_Right").GetComponent<Bird>();
      }
    }

    // Update is called once per frame
    void Update()
    {
      if(scrolling){
        //we want to be sure to update yPos once, when the bird enters the collider,
        //rather than every frame, so that we don't just move it vertically by
        //birdPosition.y meters per frame
        if(!inCollider){
          yPos = bird.birdPosition.y;
          originalYPos = gameObject.transform.position.y;
          inCollider = true;
        }//end if
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, originalYPos + bird.birdPosition.y - yPos, gameObject.transform.position.z);
      }//end if
      else{
        inCollider = false;
      }//end else
    }//end update
}
