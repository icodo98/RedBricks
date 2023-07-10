using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealBit : Bits
{
    [SerializeField]
    private  float Heal = 10f;
    public override void Power()
    {
        PlayerConroller Pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerConroller>();
        float curHP = Pc.HP;
        if (curHP + Heal > Pc.MAXHP)
        {
            Pc.HP = Pc.MAXHP;
        }
        else
        {
            Pc.HP += Heal;
        }
    }
    public override double Weight()
    {
        return weight;
    }
}
