using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : Collidable
{
    public float health;
    public float maxHp;

    public GameObject hp_bar;

    protected override void Start()
    {
        health = maxHp;
    }

    protected void TakeDmg(float dmg)
    {
        GetComponent<EnemyManager>().showText(dmg.ToString());
        if (health - dmg > 0)
        {
            health -= dmg;
            hp_bar.GetComponent<BarsManager>().setValue(health);
        }
        else
        {
            Death();
        }
    }

    private void Death()
    {
        Destroy(gameObject);
        Destroy(hp_bar);
    }
}
