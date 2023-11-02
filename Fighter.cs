using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Fighter : Collidable
{
    public int dmg = 1;
    public float ImmuneTime;
    protected float lastImmune;

    public float cooldown_hit;
    private float last_hit;

    private bool hit;

    protected override void Update()
    {
        base.Update();

        if (Input.GetKey(KeyCode.Space))
        {
            if (Time.time - last_hit > cooldown_hit)
            {
                last_hit = Time.time;
                Hit();
            }
        }
    }

    protected virtual void Hit()
    {
        gameObject.GetComponent<Charge>().StartCharging();
    }

    public void canHit()
    {
        hit = true;
    }

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.tag == "Fighter" && hit) 
            if (Time.time - lastImmune > ImmuneTime)
            {
                lastImmune = Time.time;
                //send dmg message
                coll.SendMessage("TakeDmg", dmg);
                hit = false;
            }
    }
}