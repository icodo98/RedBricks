using Cinemachine;
using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConroller : MonoBehaviour,IListener
{

    // Update is called once per frame
    public float Speed;
    Vector2 Speed_vec;
    public Rigidbody2D rb;
    Vector3 offset;
    Vector3 mousePosition;
    public float maxSpeed = 10f;
    Vector3 lastPosition;
    bool isClicked= false;

    public int MAXHP;
    public int HP;
    [SerializeField]
    private int damage = 0;

    private int _priority = 3;
    public int priority
    {
        get => _priority;
        set => _priority = value;
    }

    private void Awake()
    {
        HP = MAXHP;
    }
    private void Start()
    {
        EventManager.Instance.AddListener(myEventType.GameOver,this);
        EventManager.Instance.AddListener(myEventType.StageClear, this);
        rb = GetComponent<Rigidbody2D>();

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ball"))
        {
            HP -= damage;
            if (HP <= 0) EventManager.Instance.PostNotification(myEventType.GameOver, this);
        }
    }
   
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButton(0))
        {
            lastPosition = mousePosition;
        }
        if (Input.GetMouseButtonDown(0))
        {
            isClicked = true;
            offset = rb.transform.position - mousePosition;
         
        }
        if (Input.GetMouseButtonUp(0))
        {
            rb.velocity = Vector2.zero;
            isClicked = false;
        }
    }
    void FixedUpdate()
    {
        if (isClicked)
        {
            rb.MovePosition(mousePosition + offset);
        }
        else
        {
            Speed_vec = Vector2.zero;
            if (Input.GetKey(KeyCode.D))
            {
                Speed_vec.x += Speed;
            }
            if (Input.GetKey(KeyCode.A))
            {
                Speed_vec.x -= Speed;
            }
            rb.velocity = Speed_vec * Time.deltaTime;
        }
    }

    public void BallFallen()
    {
        HP -= (int) (MAXHP * 0.25);
        if (HP <= 0) EventManager.Instance.PostNotification(myEventType.GameOver,this);
    }
    
    void GameOver()
    {
        Destroy(gameObject);
    }
    public void OnEvent(myEventType eventType, Component Sender, object Param = null)
    {
        switch (eventType)
        {
            case myEventType.GameOver:
                GameOver();
                break;
            case myEventType.StageClear:
                List<Bits> selectedBits =  GetComponent<PlayerBits>().pickRandomBit();
                GameObject.Find("YouWin").GetComponent<WinSceneManager>().selectBit(selectedBits);
                break;
            default: throw new System.Exception("There is a unhandled event at " + this.name);
        }
    }
}
