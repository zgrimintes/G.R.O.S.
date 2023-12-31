using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : Collidable
{
    public float health;
    public float maxHp;

    protected override void Start()
    {
        health = maxHp;
    }

    protected void TakeDmg(float dmg)
    {
        GetComponent<EnemyManager>().showText(dmg.ToString());
        if (health - dmg > 0) {
            health -= dmg;
        }
        else
        {
            Death();
        }
    }

    private void Death()
    {
        Destroy(gameObject);
    }
}
