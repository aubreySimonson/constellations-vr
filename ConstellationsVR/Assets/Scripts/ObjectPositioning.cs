using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectPositioning : MonoBehaviour
{
    public Vector3 positionToMoveTo;
    void Start()
    {
        StartCoroutine(LerpPosition(positionToMoveTo, 5));
    }
    IEnumerator LerpPosition(Vector3 targetPosition, float duration)
    {
        float time = 0;
        Vector3 startPosition = transform.position;
        while (time < duration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
    }
}