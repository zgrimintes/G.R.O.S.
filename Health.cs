using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : Collidable
{
    public int health;
    public int maxHp;

    protected override void Start()
    {
        base.Start();
        health = maxHp;
    }

    protected void TakeDmg(int dmg)
    {
        if (health > 0) {
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
