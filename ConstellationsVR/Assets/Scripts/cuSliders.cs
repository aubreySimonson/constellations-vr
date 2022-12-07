using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cuSliders : MonoBehaviour
{
    // Csound
    [SerializeField] CsoundUnity csound;
    [SerializeField] string nameOfGameObject;
    [SerializeField] string[] parameters;
    [SerializeField] float[] _multiplier;

    bool soundEditing = false;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (soundEditing)
        {
            
        }
        
    }

    // When bird selects the csound instance it should add the "selected" (no capital letters) tag to the Csound object (don't forget to add this tag to the project) + call this method
    // When bird deselects the csound instance it should call this method + add the "unselected" tag to the Csound object 
    public void CsoundInstanceEditing()
    {
        if (!soundEditing)
        {
            csound = GameObject.FindGameObjectWithTag("selected").GetComponent<CsoundUnity>();
            UpdatePositionofSliders(csound);
            soundEditing = true;
        }
        else
            soundEditing = false;
    }

    void UpdatePositionofSliders(CsoundUnity instance)
    {

    }
}
