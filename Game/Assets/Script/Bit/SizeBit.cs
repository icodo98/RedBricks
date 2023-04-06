using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeBit :Bits
{
    [SerializeField]
    private float mulSize = 1.25f;
    public override void Power()
    {
        GameObject[] ball = GameObject.FindGameObjectsWithTag("Ball");
        foreach (GameObject item in ball)
        {
            item.transform.localScale = item.transform.localScale * mulSize;
        }
    }
    public override double Weight()
    {
        return weight;
    }
}
