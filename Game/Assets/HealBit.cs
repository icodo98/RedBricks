using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealBit : Bits
{
    [SerializeField]
    private int Heal = 10;
    public override void Power()
    {
        PlayerConroller Pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerConroller>();
        int curHP = Pc.HP;
        if (curHP + Heal > Pc.MAXHP)
        {
            Pc.HP = Pc.MAXHP;
        }
        else
        {
            Pc.HP += Heal;
        }
    }
}
