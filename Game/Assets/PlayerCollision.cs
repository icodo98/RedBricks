using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    void Start()

    {
      rb = GetComponent<Rigidbody2D>();
        Vector2 diagonal = new Vector2(1, -1);
        rb.AddForce(diagonal.normalized);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.name == "Ball"){
            Vector2 temp = other.transform.eulerAngles;
            temp.x = 180f - temp.x;
            other.transform.eulerAngles = temp;
            //Debug.Log(rb.GetRelativePointVelocity(other.contacts[0].point));
            //other.gameObject.GetComponent<Rigidbody2D>().AddForce(rb.GetRelativePointVelocity(other.contacts[0].point));
        }
    }
}
