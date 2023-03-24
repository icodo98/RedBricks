using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LengthBits : Bits
{
    [SerializeField]
    private float factor = 1.10f;
    public override void Power()
    {
        Vector3 temp = GameObject.FindGameObjectWithTag("Player").transform.localScale;
        temp.x = factor * temp.x;
        GameObject.FindGameObjectWithTag("Player").transform.localScale = temp;
    }

}
