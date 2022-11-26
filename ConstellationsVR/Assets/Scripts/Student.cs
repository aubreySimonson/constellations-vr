using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StudentData", menuName = "Student")]
public class Student : ScriptableObject
{

    #region PUBLIC_VERIABLE

    public string studentName;
    public int id;
    public bool teachingTeam;
    public string school;
    public string team;
    public float age;

    #endregion
}

