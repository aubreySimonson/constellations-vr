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
    public Text canaryText;
    public Text birdPosText;

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
      birdPosText.text = bird.birdPosition.ToString();
      if(bird.birdRayHit.collider != null && bird.birdRayHit.collider == thisCollider){
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, bird.birdPosition.y, gameObject.transform.position.z);
        inCollider = true;
        canaryText.text = "we hit the canary!";
      }
      else{
        if(inCollider){
          inCollider=false;
          canaryText.text = "exited the collider";
        }
      }
    }
}
