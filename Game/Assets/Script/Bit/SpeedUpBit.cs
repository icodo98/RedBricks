using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpBit : Bits
{
    [SerializeField]
    private float mulSpeed = 0.05f;
    public override void Power()
    {
        GameObject[] ball = GameObject.FindGameObjectsWithTag("Ball");
        foreach (GameObject item in ball)
        {
            Vector2 tmp = item.GetComponent<Rigidbody2D>().velocity.normalized;
            tmp = tmp * mulSpeed;
            item.GetComponent<Rigidbody2D>().velocity += tmp;
            item.GetComponent<PlayerCollision>().InitialSpeed = item.GetComponent<PlayerCollision>().InitialSpeed * (1 + mulSpeed);
            item.GetComponent<PlayerCollision>().minSpeed = item.GetComponent<PlayerCollision>().minSpeed * (1 + mulSpeed);
            item.GetComponent<PlayerCollision>().maxSpeed = item.GetComponent<PlayerCollision>().maxSpeed * (1 + mulSpeed);
        }
        
    }
    public override double Weight()
    {
        return weight;
    }
}