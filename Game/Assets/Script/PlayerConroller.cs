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

    public int MAXHP;
    public int HP;
    [SerializeField]
    private int damage = 1;

    private void Awake()
    {
        HP = MAXHP;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ball"))
        {
            HP -= damage;
            if (HP <= 0) EndGame();
        }
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
    public void BallFallen()
    {
        HP -= (int) (MAXHP * 0.25);
        if (HP <= 0) EndGame();
    }
    void EndGame()
    {
        Destroy(gameObject);
    }
}
