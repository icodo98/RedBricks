using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Freeze block after 5 hits
/// </summary>
public class FreezeBit :Bits
{
    /// <summary>
    /// Set state variable. Each block counts hits individually.
    /// </summary>
    public override void Power()
    {
        GameObject.FindGameObjectWithTag("Ball").GetComponent<PlayerCollision>().FreezeBit = true;
    }

    public override double Weight()
    {
        return weight;
    }
}
