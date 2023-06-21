using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boundary : MonoBehaviour
{
    ///ToDo 공이 벽면에 달라붙는 현상ㅇ르 수정해야함.
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Ball"))
        {
            other.transform.position = other.GetComponent<PlayerCollision>().iniPos;
        }
    }
}
