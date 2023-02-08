using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    public int  MAXHP;
    private int HP;
    void Start()

    {
      rb = GetComponent<Rigidbody2D>();
        HP = MAXHP;
        Vector2 diagonal = new Vector2(-3, 3);
        rb.AddForce(diagonal);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        /*if(other.gameObject.name == "Ball"){
            Vector2 temp = other.transform.eulerAngles;
            temp.x = 180f - temp.x;
            other.transform.eulerAngles = temp;
            //Debug.Log(rb.GetRelativePointVelocity(other.contacts[0].point));
            //other.gameObject.GetComponent<Rigidbody2D>().AddForce(rb.GetRelativePointVelocity(other.contacts[0].point));
        }*/
        if (other.gameObject.CompareTag("Block")){
            Debug.Log("Hit Blcok");
            Destroy(other.gameObject);
        }
        else if (other.gameObject.name.Equals("Bottom"))
        {
            BallHasFallen();
        }

    }
    void BallHasFallen()
    {
        HP -= (int) (MAXHP * 0.25f);
        if (HP <= 0) EndGame();
        float temp = rb.gravityScale;
        rb.gravityScale = 0;
        rb.velocity = Vector2.zero; 
        rb.angularVelocity = 0;
        rb.transform.position = new Vector3(0.02f, -1.23f, 0f);
        rb.AddForce(new Vector2(-3, 3));
        rb.gravityScale = temp;

    }
    void EndGame()
    {
        Destroy(gameObject);
    }
}
