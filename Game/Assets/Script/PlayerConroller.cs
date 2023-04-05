using System.Collections;
using UnityEngine;

public class PlayerConroller : MonoBehaviour,IListener
{

    // Update is called once per frame
    public float Speed;
    Vector2 Speed_vec;

    public int MAXHP;
    public int HP;
    [SerializeField]
    private int damage = 1;

    private void Awake()
    {
        HP = MAXHP;
    }
    private void Start()
    {
        EventManager.Instance.AddListener(myEventType.GameOver,this);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ball"))
        {
            HP -= damage;
            if (HP <= 0) EventManager.Instance.PostNotification(myEventType.GameOver, this);
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
    }
    public void BallFallen()
    {
        HP -= (int) (MAXHP * 0.25);
        if (HP <= 0) EventManager.Instance.PostNotification(myEventType.GameOver,this);
    }
    
    void GameOver()
    {
        Time.timeScale = 0.1f;
        Destroy(gameObject);
    }
    public void OnEvent(myEventType eventType, Component Sender, object Param = null)
    {
        switch (eventType)
        {
            case myEventType.GameOver:
                GameOver();
                break;
        }
    }
}
