using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubAngleBit : Bits
{
    public override void Power()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PolygonGenerator>().Draw(--player.GetComponent<PolygonGenerator>().polygonPoints);
    }
}
