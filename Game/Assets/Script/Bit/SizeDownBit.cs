using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeDownBit : Bits
{
    [SerializeField]
    private float mulSize = 0.75f;
    public override void Power()
    {
        GameObject[] ball = GameObject.FindGameObjectsWithTag("Ball");
        foreach (GameObject item in ball)
        {
            if(item.transform.localScale.x > 0.15f)
            {
                item.transform.localScale = item.transform.localScale * mulSize;
            }
        }
    }
    public override double Weight()
    {
        return weight;
    }
}
