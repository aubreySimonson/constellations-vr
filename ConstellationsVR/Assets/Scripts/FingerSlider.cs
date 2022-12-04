
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FingerSlider : MonoBehaviour
{
    public GameObject pointer; //whatever you want to use to paint
    public GameObject pointerPrefab;
    public GameObject marker;
    private float output;
    public Text debugText;
    public Text debugText2;
    public Text debugText3;
    public Text debugText4;
    public GameObject hand;//should be a gameobject with OVRSkeleton on it
    OVRSkeleton skeleton;
    OVRBone indexBone;

    // Start is called before the first frame update
    void Start()
    {
        output = 0.0f;
        if(pointer == null){
          pointer = GameObject.Find("Pointer");
        }
        if(pointer!=null){
          debugText.text = "pointer found";
        }

        //this is the system that we use to put our pointer on the index finger,
        //because the hand is created at runtime.
        //It's a little stupid right now, because it will generate a new pointer for every slider
        //good candidate for refactoring
        skeleton = GetComponent<OVRSkeleton>();
        debugText2.text = "skeleton found";
        //we care about Hand_Index3
        foreach (OVRBone bone in skeleton.Bones)
        {
          if (bone.Id == OVRSkeleton.BoneId.Hand_Index3)
          {
            pointer = Instantiate(pointerPrefab);
            indexBone = bone;
            debugText4.text = bone.Transform.position.ToString();
            pointer.transform.position = bone.Transform.position;
            pointer.transform.SetParent(bone.Transform, true);
            debugText3.text = "Start complete";
          }
        }
    }

    // Update is called once per frame
    void Update()
    {
        debugText4.text = indexBone.Transform.position.ToString();
        RaycastHit hit;
        if (Physics.Raycast(pointer.transform.position, pointer.transform.up, out hit, 100.0f))//we've tried forward
        {
            if(hit.collider.gameObject.name == "SliderHitArea")
            {
                //you need to convert everything to local coordinates so that it has the right axis and everything
                Vector3 localHit = transform.InverseTransformPoint(hit.point);
                float markerX = marker.transform.localPosition.x;
                float markerY = marker.transform.localPosition.y;
                float markerZ = marker.transform.localPosition.z;
                //marker.transform.position = hit.point;
                marker.transform.localPosition = new Vector3(markerX, localHit.y, markerZ);
                debugText4.text = localHit.y.ToString();
                output = localHit.y + 0.5f * 10.0f;//makes it 0-1
                debugText.text = output.ToString();
            }//end if
        }//end if
    }//end update
}//end class
