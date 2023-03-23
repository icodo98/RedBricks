using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltBits :Bits
{
    public override void Power()
    {
        GameObject.FindGameObjectWithTag("Player").transform.eulerAngles = new Vector3(0, 0, 20);
    }

}
