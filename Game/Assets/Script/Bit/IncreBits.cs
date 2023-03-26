using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreBits : Bits
{
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private Vector3 OriPos = new Vector3(0.02f, -1.23f,0);
    public override void Power()
    {
        Instantiate(prefab,OriPos , Quaternion.identity); ;
    }

}
