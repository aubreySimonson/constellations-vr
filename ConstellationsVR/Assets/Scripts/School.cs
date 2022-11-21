using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SchoolName
{
    Harvard, Berklee, MIT
}

public class School : MonoBehaviour
{
    [SerializeField] SchoolName school;
}
