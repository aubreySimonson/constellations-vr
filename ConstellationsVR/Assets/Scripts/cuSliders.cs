using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cuSliders : MonoBehaviour
{
    // Csound
    [SerializeField] CsoundUnity csound;
    [SerializeField] GameObject csoundGameObject;
   [SerializeField] string[] parameters;
    [SerializeField] float[] _multiplier;

    [SerializeField] GameObject[] _sliders;

    bool soundEditing = false;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (soundEditing)
        {
            
        }
        
    }

    // When bird selects the csound instance it should add the "selected" (no capital letters) tag to the Csound object (don't forget to add this tag to the project) + call this method
    // When bird deselects the csound instance it should call this method + add the "unselected" tag to the Csound object 
    public void CsoundInstanceEditing()
    {
        if (!soundEditing)
        {
            csoundGameObject = GameObject.FindGameObjectWithTag("selected");
            csound = csoundGameObject.GetComponent<CsoundUnity>();
            UpdatePositionofSliders(csoundGameObject);
            soundEditing = true;
        }
        else
            soundEditing = false;
    }

    void UpdatePositionofSliders(GameObject csoundGameObject)
    {
        for (int i = 0; i < _sliders.Length; i++)
        {
            float sliderValue = csoundGameObject.GetComponent<CsoundPresetData>().UpdateValues(i);
            _sliders[i].transform.localPosition = new Vector3(transform.position.x, sliderValue , transform.position.z); // physical movement of slider
        }
    }
}
