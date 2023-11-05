using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charge : MonoBehaviour
{
    private Vector3 positionToMove;
    private Vector3 dir;
    private float startTime = 0f;
    public float endTime = 0f;
    private float dmg;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            startTime = Time.time;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            endTime = Time.time - startTime; //I'm counting for how long is the space bar pressed
            if (endTime > 1)
            {
                endTime = 1;  
            }
        }
    }

    public void StartCharging()
    {
        gameObject.GetComponent<Walking>().canLook = false; //Make so the player can't rotate while they are charging
        dir = gameObject.GetComponent<Walking>().direction * 2; //Here I am using the dir from the walking script
        positionToMove = gameObject.transform.position + dir;   //and using it I'm setting in which direction the character will charge
        StartCoroutine(Charging(positionToMove, 0.6f));
    }

    IEnumerator Charging(Vector3 targetPosition, float duration)
    {
        float time = 0;
        Vector3 startPosition = transform.position;
        while (!Input.GetKeyUp(KeyCode.Space))  
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        dmg = 1 * (endTime + 0.5f * endTime * 2); //Scale the damage with the time the player charged
        GetComponent<Fighter>().canHit(true, dmg); //Make it so the goat can hit

        time = 0;
        Vector3 midChargePos = transform.position;
        Vector3 returnPos = startPosition - dir * endTime * 2;
        if (endTime > 0.2f)
        {
            while (transform.position != returnPos && time < 1)
            { 
                transform.position = Vector3.Lerp(midChargePos, returnPos, (time * endTime * 10) / duration);;
                time += Time.deltaTime;
                yield return null;
            }
        }
        else
        {
            returnPos = startPosition - dir * endTime;
            while (transform.position != returnPos)
            {
                transform.position = Vector3.Lerp(midChargePos, returnPos, (time * endTime * 100) / duration); ;
                time += Time.deltaTime;
                yield return null;
            }
        }
        gameObject.GetComponent<Walking>().canLook = true;

        GetComponent<Fighter>().canHit(false, dmg); //Make it so the goat can't hit
    }
}
