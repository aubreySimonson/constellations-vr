//a small tool for making a console write to within the Oculus Quest, because debugging on this thing is a nightmare
//attach this script to a 500x500 panel wherever you'd like as a child of a worldspace canvas
//don't forget to give it a reasonable message prefab


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConsoleUI : MonoBehaviour
{
    public float y;//the y coord of the next thing

    public float yInterval; //how much to move down between logs

    public GameObject messagePrefab;

    public void log(string txt)
    {
        //Instantiate message prefab as a child of the panel, at x as message
        GameObject message = Instantiate(messagePrefab, gameObject.transform);
        message.transform.localPosition = new Vector3(0, y, 0);
        y -= yInterval;
        message.GetComponent<Text>().text = txt;
    }
}
