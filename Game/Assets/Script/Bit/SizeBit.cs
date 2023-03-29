using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeBit :Bits
{
    [SerializeField]
    private float mulSize = 1.25f;
    public override void Power()
    {
        GameObject.Find("Ball").transform.localScale = GameObject.Find("Ball").transform.localScale * mulSize; 
    }
    public override double Weight()
    {
        return weight;
    }
}
