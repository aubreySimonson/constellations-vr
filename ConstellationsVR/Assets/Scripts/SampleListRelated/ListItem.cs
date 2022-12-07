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

    public ObjectManager objectManager;
    public int id;//should be told about this by GenerateList when the list is generated
    public GameObject soundSpherePrefab;

    [SerializeField] UnityEvent OnTouch;
    [SerializeField] UnityEvent OnRelease;

    // Start is called before the first frame update
    void Start()
    {
      if(bird == null){
        bird = GameObject.Find("OVRHandPrefab_Right").GetComponent<Bird>();
      }
      if(listScroll == null){
        listScroll = GameObject.Find("SamplesListGameObject").GetComponent<ListScroll>();
      }
      if(objectManager == null){
        objectManager = GameObject.Find("Object Manager").GetComponent<ObjectManager>();
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

    //this function exists so that we can reference it in the ontouch unity event in the same game object
    //instantiation at runtime is a strange place
    public void CreateSampleSphere(){
      GameObject newSampleSphere = Instantiate(soundSpherePrefab);
      newSampleSphere.transform.position = gameObject.transform.position;//we'll place this better later...
      newSampleSphere.GetComponent<SampleSelector>()._id = id;
      objectManager.SelectingSample(id);
    }
}
