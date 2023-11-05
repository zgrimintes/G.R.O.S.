using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Fighter : Collidable
{
    public Damage damage;
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

    public void canHit(bool IO, float dmg)
    {
        damage.setBonus(dmg);//Sets a dmg bonus based on the time the player had charged
        hit = IO;
        damage.dmg = dmg * damage.dmgBonus;
        damage.dmg = (int)(damage.dmg * 10f) / 10f;
    }

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.tag == "Fighter" && hit) 
            if (Time.time - lastImmune > ImmuneTime)
            {
                lastImmune = Time.time;
                //send dmg message
                coll.SendMessage("TakeDmg", damage.dmg);
                hit = false;
            }
    }
}
