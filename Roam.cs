using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class Roam : MonoBehaviour
{
    private float timeToStay = 0;
    public float lastStop;

    private Vector3 dirToMove;
    BoxCollider2D m_Colider; //Reference to the component BoxCollider2D of th ground sprite

    private void Start()
    {
        GameObject gorund = GameObject.FindWithTag("Ground");
        m_Colider = gorund.GetComponent<BoxCollider2D>(); //Set the variable
    }

    private void Update()
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
        do
        {
            Vector3 rot = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0);
            transform.up = rot - transform.position;

            dirToMove = transform.position - rot;
        } while (canGo(dirToMove)); //Repeats until you find a valid spot on the map
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

    private bool canGo(Vector3 destination) //This verifies if the position the sheeps are trying to go to is valid
    {
        if (m_Colider.bounds.Contains(destination))
            return false;
        return true;
    }

}
