using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxHealBit : Bits
{
    [SerializeField]
    private int MaxHeal;
    public override void Power()
    {
        PlayerConroller Pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerConroller>();
        Pc.MAXHP += MaxHeal;
        Pc.HP += MaxHeal;
    }
}