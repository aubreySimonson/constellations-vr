//Part of ConstellationsVR
//
//This script goes on the Sliders game object, and manages the connection between
//slider values and CSound values on the current CSound object

//???-->Mateo
//Last edited Dec 2022

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cuSliders : MonoBehaviour
{
    // Csound
    [SerializeField] CsoundUnity csound;
    [SerializeField] GameObject csoundGameObject;
    // Parameters - CsoundUnity Communication
    [SerializeField] string[] parameters;
    [SerializeField] float[] _multiplier;
    [SerializeField] GameObject[] _sliders;
    [SerializeField] FingerSlider[] _fingerSliders;

    // Editing
    bool soundEditing = false;
    // Reference to Object Manager
    public ObjectManager objectManager;





    // Start is called before the first frame update
    void Start()
    {
        objectManager = GameObject.Find("Object Manager").GetComponent<ObjectManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // Logic to send data to Csound
        if (soundEditing)
        {
            csound = csoundGameObject.GetComponent<CsoundUnity>();

            for (int i = 0; i < parameters.Length; i++)
            {
                csound.SetChannel(parameters[i], _fingerSliders[i].GetSliderValue() * _multiplier[i]);
            }
        }

    }

    // When bird selects the csound instance it should add the "selected" (no capital letters) tag to the Csound object (don't forget to add this tag to the project) + call this method
    // When bird deselects the csound instance it should call this method + add the "unselected" tag to the Csound object
    // Updated this to jut call UpdatePositionofSliders when we select, and call SavePreset when we deselect, thus making this function obscelete --Aubrey 12/14/22
    public void CsoundInstanceEditing()
    {

        csoundGameObject = objectManager.currentCsoundObject;

        if (!soundEditing)
        {
            //csoundGameObject = GameObject.FindGameObjectWithTag("selected");
            UpdatePositionofSliders(csoundGameObject);
            soundEditing = true;
        }
        else
        {
            soundEditing = false;
            SavePreset();

        }
    }

    // Positions sliders based on the current Csound Values
    public void UpdatePositionofSliders(GameObject csoundGameObject)
    {
        for (int i = 0; i < _sliders.Length; i++)
        {
            //_sliders[i].transform.localPosition = new Vector3(transform.position.x, csoundGameObject.GetComponent<CsoundPresetData>().UpdateValues(i) , transform.position.z); // physical movement of slider
            //let the finger sliders do this instead
            _fingerSliders[i].SetMarkerAndOutputToValue(csoundGameObject.GetComponent<CsoundPresetData>().UpdateValues(i));
        }
    }

    // Stores 'preset' info in the individual Csound instance
    public void SavePreset()
    {
        //let the finger sliders do this instead
        // float volume = _sliders[0].transform.localPosition.y;
        // float pitch = _sliders[1].transform.localPosition.y;
        // float stringresonance = _sliders[2].transform.localPosition.y;
        // float reverb = _sliders[3].transform.localPosition.y;
        // float echo = _sliders[4].transform.localPosition.y;

        float volume = _fingerSliders[0].GetSliderValue();
        float pitch = _fingerSliders[1].GetSliderValue();
        float stringresonance = _fingerSliders[2].GetSliderValue();
        float reverb = _fingerSliders[3].GetSliderValue();
        float echo = _fingerSliders[4].GetSliderValue();
        csoundGameObject.GetComponent<CsoundPresetData>().SetValues(volume, pitch, stringresonance, reverb, echo);

    }
}
