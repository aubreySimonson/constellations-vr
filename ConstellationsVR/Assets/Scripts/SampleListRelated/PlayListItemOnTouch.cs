//Part of ConstellationsVR
//
//Causes a list item to make Object Manager play the associated audio clip when touched with bird.
//Select behind behavior (if the bird is through the item, it still does this)

//???-->Aubrey at followspotfour@gmail.com
//Last edited Dec 2022

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayListItemOnTouch : MonoBehaviour
{

    public Bird bird;
    Collider thisCollider;//collider component of the object this script is on

    public ObjectManager objectManager;
    public int id;//the id for the student associated with this list item

    // Start is called before the first frame update
    void Start()
    {
      if(bird == null){
        bird = GameObject.Find("OVRHandPrefab_Right").GetComponent<Bird>();
      }
      if(objectManager == null){
        objectManager = GameObject.Find("Object Manager").GetComponent<ObjectManager>();
      }
      thisCollider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
      if(bird.birdRayHit.collider != null && bird.birdRayHit.collider == thisCollider){
        objectManager.ScrollingThroughSamples(id);
      }//end if
    }//end update
}//end class
