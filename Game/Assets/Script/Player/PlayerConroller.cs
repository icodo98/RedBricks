using Cinemachine;
using Mono.Cecil;
using PlayerInformation;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    private bool isPaused;
    public int MAXHP;
    public int HP;

    public GameObject hudDamageText;

    private int _priority = 3;
    public int priority
    {
        get => _priority;
        set => _priority = value;
    }

    private void Start()
    {
        EventManager.Instance.AddListener(myEventType.GameOver,this);
        EventManager.Instance.AddListener(myEventType.StageClear, this);
        EventManager.Instance.AddListener(myEventType.GamePause, this);
        EventManager.Instance.AddListener(myEventType.GameResume, this);
        rb = GetComponent<Rigidbody2D>();
        if (PlayerInfo.playerInfo.curData.AddBall) Invoke("AddBall", 1.5f);
        if (PlayerInfo.playerInfo.curData.IncreaseHealth > 1) MAXHP = PlayerInfo.playerInfo.curData.IncreaseHealth * MAXHP;
        PlayerInfo.playerInfo.HP = MAXHP;
        HP = PlayerInfo.playerInfo.HP;


        isPaused = false;
    }
    private void AddBall()
    {
        IncreBits b1 = new();
        b1.Power();
    }
    private void TakeDamage(float damage)
    {
        int intDamage = Mathf.FloorToInt(damage);
        if (intDamage < 0) intDamage = 0;
        HP -= intDamage;
        DisplayDamage(intDamage, this.transform.position);
        if (HP <= 0)
        {
            EventManager.Instance.PostNotification(myEventType.GameOver, this);
        }

    }
    public void Resurrection()
    {
        HP = MAXHP / 2;
    }
    /// <summary>
    /// 데미지 계산 함수. isTrue 가 true일 경우 유저의 방어력 수치를 무시한 데미지가 들어온다.
    /// </summary>
    /// <param name="damage"> 입을 데미지</param>
    /// <param name="isTrue"> true 일 경우 방어력 무시</param> 
    public void TakeDamage(float damage, bool isTrue)
    {
        if(isTrue) TakeDamage(damage);
        else TakeDamage(damage - PlayerInfo.playerInfo.curData.Amor);
    }
    void Update()
    {
        if(isPaused) return;
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
    /// <summary>
    /// 공을 떨어뜨렸을 때 입을 데미지 계산. 패널티 감소를 올려 놓았다면 0.25 -> 0.2 -> 0.15 순으로 적은 데미지를 받는다.
    /// </summary>
    public void BallFallen()
    {
        float fallenDamage = (PlayerInfo.playerInfo.curData.FallingPenalty < 1) ? 0.25f :
            (PlayerInfo.playerInfo.curData.FallingPenalty < 2) ? 0.2f : 0.15f;
        TakeDamage(MAXHP * fallenDamage,true);
    }
    
    void GameOver()
    {
        gameObject.SetActive(false);
    }
    private void DisplayDamage(int damage, Vector3 hudPos)
    {
        GameObject hudText = Instantiate(hudDamageText);
        hudText.transform.position = hudPos;
        hudText.GetComponent<DamageText>().damage = damage;
    }
    public void OnEvent(myEventType eventType, Component Sender, object Param = null)
    {
        switch (eventType)
        {
            case myEventType.GamePause:
                isPaused = true;
                break;
            case myEventType.GameResume:
                isPaused = false;
                gameObject.SetActive(true);
                if (Sender.gameObject.name == "YouBroken") Resurrection();
                break;
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
    private void OnDestroy()
    {
        PlayerInfo.playerInfo.HP = HP;
    }
}
