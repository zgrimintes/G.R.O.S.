using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collidable : MonoBehaviour
{
    public ContactFilter2D filter;
    public BoxCollider2D boxCollider;
    public Collider2D[] hits = new Collider2D[10];

    protected virtual void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        //Application.targetFrameRate = 12;
    }

    protected virtual void Update()
    {
        if (boxCollider) 
        {
            boxCollider.OverlapCollider(filter, hits);
            for (int i = 0; i < hits.Length; i++)
            {
                if (hits[i] == null)
                {
                    continue;
                }

                OnCollide(hits[i]);

                hits[i] = null;
            }
        }
    }

    protected virtual void OnCollide(Collider2D coll)
    {
        //Debug.Log(coll.name);
    }
}
