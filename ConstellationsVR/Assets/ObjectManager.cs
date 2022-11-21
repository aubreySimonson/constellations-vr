using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    // Csound Object - for sound editing
    [SerializeField] GameObject CsoundEditor; // Object where sample is attached
    [SerializeField] Transform startingPosition;
    int numberOfCsoundUnityInstances = 0;


    public void InstantiateCsoundObject()
    {
        numberOfCsoundUnityInstances++;
        GameObject copy = Instantiate(CsoundEditor, startingPosition);
        copy.name = numberOfCsoundUnityInstances.ToString();
    }
}
