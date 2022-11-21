using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    // Csound Object - for sound editing
    [SerializeField] GameObject CsoundEditor; // Object where sample is attached
    [SerializeField] Transform startingPosition;
    int numberOfCsoundUnityInstances = 0;

    // Sample Mgmt
    public bool vocalMode = true; // vocal Samples are displayed (true), project samples are displayed (false)
    [SerializeField] AudioClip[] vocalSamples;
    [SerializeField] AudioClip[] projectSamples;
    [SerializeField] GameObject sampleObject;


    // Audio Source for interface (plays sample when hovering over name)
    [SerializeField] AudioSource _source;


    public void InstantiateCsoundObject()
    {
        numberOfCsoundUnityInstances++;
        GameObject copy = Instantiate(CsoundEditor, startingPosition);
        copy.name = "CU" + numberOfCsoundUnityInstances.ToString();
    }

    public void ToggleBetweenSampleModes()
    {
        if (vocalMode)
            vocalMode = false;
        else
            vocalMode = true;
    }

    public void ScrollingThroughSamples(int id)
    {
        if (vocalMode)
        {
            _source.clip = vocalSamples[id];
        }
        else
        {
            _source.clip = projectSamples[id];
        }

        _source.Play();
    }

    public void SelectingSample(int id)
    {

     
    }
}
