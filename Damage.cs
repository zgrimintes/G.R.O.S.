using UnityEngine;
using UnityEngine.Rendering;

public struct Damage
{
    public Vector3 origin;
    public float dmg;
    public float dmgBonus;
    public float pushForce;

    public void setBonus(float dmgBonus)
    {
        if (dmgBonus < 1)
        {
            this.dmgBonus = 1;
        }
        else if (dmgBonus == 2)
        {
            this.dmgBonus = Random.Range(2f, 4f);
        }
        else
        {
            this.dmgBonus = Random.Range(1f, 2f);
        }
    }
};
