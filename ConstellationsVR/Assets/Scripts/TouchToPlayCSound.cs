//Part of ConstellationsVR
//
//Causes a gameObject play the associated audio clip when touched with bird.
//Designed to be used with SampleSpheres and CSoundObjects
//Select behind behavior (if the bird is through the item, it still does this)

//???-->Aubrey at followspotfour@gmail.com
//Last edited Dec 2022
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchToPlayCSound : MonoBehaviour
{
    public Text debugText;

    public Bird bird;
    Collider thisCollider;//collider component of the object this script is on

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
        //MATEO-- this is the bit where we would say audioSource.Play(), but, like, the Csound version
        debugText.text = "it works!";
      }//end if
    }
}
