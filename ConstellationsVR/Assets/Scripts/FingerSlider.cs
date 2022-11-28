
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FingerSlider : MonoBehaviour
{
    public GameObject pointer; //whatever you want to use to paint
    public GameObject marker;
    private float output;
    public Text debugText;
    public Text debugText2;
    public Text debugText3;

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
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;
        if (Physics.Raycast(pointer.transform.position, pointer.transform.forward, out hit, 10.0f))
        {
            debugText2.text = "raycast happens";
            if(hit.collider.gameObject.name == "SliderHitArea")
            {
                //you need to convert everything to local coordinates so that it has the right axis and everything
                Vector3 localHit = transform.InverseTransformPoint(hit.point);
                float markerX = marker.transform.localPosition.x;
                float markerY = marker.transform.localPosition.y;
                float markerZ = marker.transform.localPosition.z;
                //marker.transform.position = hit.point;
                marker.transform.localPosition = new Vector3(markerX, localHit.y, markerZ);
                output = localHit.y + 0.5f;//makes it 0-1
                debugText.text = output.ToString();
            }//end if
        }//end if
    }//end update
}//end class
