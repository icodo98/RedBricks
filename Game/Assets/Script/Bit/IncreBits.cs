using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * ���� ������ �ϳ� �÷���.
 */
public class IncreBits : Bits
{
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private Vector3 OriPos = new Vector3(0.02f, -1.23f,0);
    public override void Power()
    {
        prefab = GameObject.FindGameObjectWithTag("Ball");
        Instantiate(prefab,OriPos , Quaternion.identity);
    }

    public override double Weight()
    {
        return weight;
    }
}
