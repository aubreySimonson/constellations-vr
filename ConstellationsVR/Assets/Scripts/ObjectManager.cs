using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectManager : MonoBehaviour
{
    // Csound Object - for sound editing
    //[SerializeField] GameObject CsoundEditor; // Object where sample is attached
    [SerializeField] Transform startingPosition;
    [SerializeField] GameObject CsoundObject;//this is the Csound object we are currently interacting with
    public int numberOfCsoundUnityInstances = 0;
    int numberOfStudent;

    // Tracking Current Objects in Scene
    [SerializeField] GameObject[] inScene;

    // Sample Mgmt
    public bool vocalMode = true; // vocal Samples are displayed (true), project samples are displayed (false)
    [SerializeField] GameObject sampleObject;


    // Audio Source for scrollable sample list (plays sample when hovering over name)
    [SerializeField] AudioSource _source;


    // Students - Data Structure
    //Aubrey set this to public so that we can get at it from GenerateList.cs
    //Let me know if this is an issue --December 6th, 2022
    public Student[] students;


    // Positioning
    [SerializeField] Vector3[] SchoolPosition; // 0 = Berklee, 1 = Harvard, 2 = MIT
    [SerializeField] Vector3[] GroupPosition; // 0 = Aura, 1 = Magic, 2 = MusiCraft, 3 = Sonic Soup, 4 = StageFreight
    Vector3 result;


    public void InstantiateCsoundObject()
    {
        numberOfCsoundUnityInstances++;
        GameObject copy = Instantiate(CsoundObject, startingPosition);
        copy.name = "CU" + numberOfCsoundUnityInstances.ToString();
    }

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
            int correctID = (int)numberOfStudent / 2 + id; //Allows to have one single Csound.Load
            _source.clip = students[correctID].projectSample;
        }

        _source.Play();
    }

    public void StopSample()
    {
        _source.Stop();
    }

    public void SelectingSample(int id)
    {

        GameObject instance = Instantiate(sampleObject);
        UpdateInformation(id, instance);

    }

    void UpdateInformation(int id, GameObject instance)
    {
        instance.name = students[id].name;
        instance.tag = "Sound Object"; // Don't forget to add this tag to project
        instance.GetComponent<SampleSelector>()._id = id;
        instance.GetComponent<ObjectLogic>().studentData = students[id]; // Don't forget to add ObjectLogic.cs to sample object

    }

    public void Sorting(int mode) // s = school, g = group, r = random
    {
        UpdateCurrentObjectsInScene();


        switch (mode)
        {
            case 0: // School Sorting
                for (int i = 0; i < inScene.Length; i++)
                {
                    string school = inScene[i].GetComponent<ObjectLogic>().studentData.school;
                    Vector3 offset = new Vector3(Random.Range(0, 3), Random.Range(0, 3), Random.Range(0, 3));

                    switch (school)
                    {
                        case "Berklee":
                            result = SchoolPosition[0] + offset;
                            break;
                        case "Harvard":
                            result = SchoolPosition[1] + offset;
                            break;
                        case "MIT":
                            result = SchoolPosition[2] + offset;
                            break;
                        case "Null":
                            result = SchoolPosition[3] + offset;
                            break;
                    }

                    StartCoroutine(LerpPosition(result, 5, inScene[i]));
                }

break;
            case 1: // Group Sorting

                break;
            case 2: // Random

                break;
        }
    }

    void UpdateCurrentObjectsInScene()
{
    inScene = GameObject.FindGameObjectsWithTag("Sound Object");
}

IEnumerator LerpPosition(Vector3 targetPosition, float duration, GameObject currentObject)
{
    float time = 0;
    Vector3 startPosition = currentObject.transform.position;
        while (time<duration)
        {
            currentObject.transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        currentObject.transform.position = targetPosition;
    }

}

