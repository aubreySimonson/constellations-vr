using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    // Csound Object - for sound editing
    //[SerializeField] GameObject CsoundEditor; // Object where sample is attached
    [SerializeField] Transform startingPosition;
    int numberOfCsoundUnityInstances = 0;

    // Sample Mgmt
    public bool vocalMode = true; // vocal Samples are displayed (true), project samples are displayed (false)
    [SerializeField] AudioClip[] vocalSamples;
    [SerializeField] AudioClip[] projectSamples;
    [SerializeField] GameObject sampleObjectStudent;
    [SerializeField] GameObject sampleObjectTeachingTeam;


    // Audio Source for interface (plays sample when hovering over name)
    [SerializeField] AudioSource _source;


    // Students - Data Structure
    [SerializeField] Student[] students;


    //public void InstantiateCsoundObject()
    //{
    //    numberOfCsoundUnityInstances++;
    //    GameObject copy = Instantiate(CsoundEditor, startingPosition);
    //    copy.name = "CU" + numberOfCsoundUnityInstances.ToString();
    //}

    public void ToggleBetweenSampleModes()
    {
        if (vocalMode)
            vocalMode = false;
        else
            vocalMode = true;
    }

    // Hover over the text should trigger the sample
    public void ScrollingThroughSamples(int id)
    {
        if (vocalMode)
        {
            _source.clip = students[id].vocalSample;
        }
        else
        {
            _source.clip = students[id].projectSample;
        }

        _source.Play();
    }

    public void SelectingSample(int id)
    {
        if (students[id].teachingTeam)
        {
            GameObject instance = Instantiate(sampleObjectTeachingTeam);
            UpdateInformation(id, instance);
        }
        else
        {
            GameObject instance = Instantiate(sampleObjectStudent);
            UpdateInformation(id, instance);
        }

    }

    void UpdateInformation(int id, GameObject instance)
    {
        instance.name = students[id].name;
        instance.tag = students[id].school; // Remember to add these tags to the project
    }

}
