//Part of ConstellationsVR
//
//Generates a list of ListItemPrefabs (we really need better variable names)
//based on the student array on ObjectManager

//???-->Aubrey at followspotfour@gmail.com
//Last edited Dec 2022

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateList : MonoBehaviour
{
    public ObjectManager objectManager;
    public GameObject listItemPrefab;
    public GameObject samplesList;

    public float y;//the y coord of the next thing
    public float yInterval; //how much to move down between items

    // Start is called before the first frame update
    void Start()
    {
      foreach(Student student in objectManager.students){
        Debug.Log(student.studentName);//for debugging
        GameObject currentListItem = Instantiate(listItemPrefab);
        currentListItem.GetComponent<Text>().text = student.studentName;
        currentListItem.transform.parent = samplesList.transform;
        currentListItem.transform.localScale = new Vector3(1f, 1f, 1f);
        currentListItem.transform.localPosition = new Vector3(0f, y, 0f);
        y-=yInterval;
        //the fact that we have to tell both scripts about this is sort of annoying,
        //and a good candidate for refactoring...
        currentListItem.GetComponent<ListItem>().id = student.id;
        currentListItem.GetComponent<PlayListItemOnTouch>().id = student.id;
      }
    }
}
