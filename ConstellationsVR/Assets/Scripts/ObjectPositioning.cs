using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPositioning : MonoBehaviour
{
    public float speed = 0.5f;

    private Vector3 start;
    public Vector3 destination;
    private float fraction = 0;


    void Start()
    {
        start = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    void Update()
    {

        if (fraction < 1)
        {
            fraction += Time.deltaTime * speed;
            transform.position = Vector3.Lerp(start, destination, fraction);
        }
    }

}




