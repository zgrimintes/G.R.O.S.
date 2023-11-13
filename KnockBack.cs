using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KnockBack : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float strenght, delay = 0.16f;

    public UnityEvent OnBegin, OnEnd; //Two events for stopping the modification of the velocity across the gameObject

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void knockBack(GameObject sender)
    {
        StopAllCoroutines();
        OnBegin.Invoke(); //Stop the velocity
        Vector2 direction = (transform.position - sender.transform.position).normalized;
        rb.AddForce(direction * strenght, ForceMode2D.Impulse);
        StartCoroutine(Reset());
    }


    private IEnumerator Reset()
    {
        yield return new WaitForSeconds(delay);
        rb.velocity = Vector3.zero;
        OnEnd.Invoke(); //Enable the velocity
    }

}
