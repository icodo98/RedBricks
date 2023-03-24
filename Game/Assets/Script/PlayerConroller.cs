using Codice.CM.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConroller : MonoBehaviour
{

    // Update is called once per frame
    public float Speed = 5.0f;
    Vector2 Speed_vec;
    float h, v;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Hitted : "+ collision.gameObject.name);
    }
    void FixedUpdate()
    {
        Speed_vec = Vector2.zero;
        if(Input.GetKey(KeyCode.D)) {
            Speed_vec.x += Speed;
        }if(Input.GetKey(KeyCode.A)) {
            Speed_vec.x -= Speed;
        }
        GetComponent<Rigidbody2D>().velocity = Speed_vec * Time.deltaTime;
        //GetComponent<Rigidbody2D>().AddForce(Speed_vec);
    }
 }
