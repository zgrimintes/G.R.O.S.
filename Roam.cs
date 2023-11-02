using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roam : MonoBehaviour
{
    private float timeToStay = 0;
    private float lastStop;

    private Vector3 dirToMove;

    void Update()
    {
        if (Time.time - lastStop > timeToStay)
        {
            lastStop = Time.time;
            timeToStay = 4;
            chooseDirection();
            StartCoroutine(moveToPos(dirToMove, 2f));
        }
    }

    private void chooseDirection()
    {
        Vector3 rot = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0);
        transform.up = rot - transform.position;

        dirToMove = transform.position - rot;
    }

    IEnumerator moveToPos(Vector3 targetPosition, float duration)
    {
        float time = 0;
        while (targetPosition != transform.position && time < duration)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        yield return null;
    }
}
