using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CsoundPresetData : MonoBehaviour
{
    [SerializeField] float[] valueSliders;

    public float UpdateValues(int index)
    {
        return valueSliders[index];
    }
}
