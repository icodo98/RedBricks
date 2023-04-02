using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpBit : Bits
{
    [SerializeField]
    private float mulSpeed = 0.05f;
    public override void Power()
    {
        GameObject ball = GameObject.Find("Ball");
        Debug.Log(ball.GetComponent<Rigidbody2D>().velocity.magnitude);
        // ball.GetComponent<Rigidbody2D>().AddForce(ball.GetComponent<Rigidbody2D>().velocity.normalized * ball.GetComponent<PlayerCollision>().speed * mulSpeed);
        Vector2 tmp = ball.GetComponent<Rigidbody2D>().velocity.normalized;
        tmp = tmp * mulSpeed;
        ball.GetComponent<Rigidbody2D>().velocity += tmp;
        Debug.Log(ball.GetComponent<Rigidbody2D>().velocity.magnitude);


    }
    public override double Weight()
    {
        return weight;
    }
}