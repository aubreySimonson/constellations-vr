//Part of ConstellationsVR
//
//Every CSound Object has a copy of this script.
//It stores the slider values when the CSound Object is not being edited.

//???-->Mateo
//Last edited Dec 2022

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CsoundPresetData : MonoBehaviour
{
    [SerializeField] float[] valueSliders = new float[5]; // 5 sliders
    GameObject cuSliders;


    public void SetValues(float volumeSlider, float pitchSlider, float stringresonance, float reverb, float echo)
    {
        valueSliders[0] = volumeSlider;
        valueSliders[1] = pitchSlider;
        valueSliders[2] = stringresonance;
        valueSliders[3] = reverb;
        valueSliders[4] = echo;

    }

    //it's on Aubrey's to do list to eventually rename this to "GetValues" and resolve any hacov that causes
    public float UpdateValues(int index)
    {
        return valueSliders[index];
    }

}
