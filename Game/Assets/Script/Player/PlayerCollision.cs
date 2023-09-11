using System.Collections.Generic;
using UnityEngine;
using PlayerInformation;
using static UnityEditor.PlayerSettings;

public class PlayerCollision : MonoBehaviour
{
    public ParticleSystem woodbreak;
  
    private Rigidbody2D rb;
    public float InitialSpeed = 3.5f;
    public Vector3 iniPos = new Vector3(0.02f, -1.23f, 0f);
    [SerializeField]
    private float BitDropRate = 0.5f;
    [SerializeField]
    public float maxSpeed = 7.0f;
    [SerializeField]
    public float minSpeed = 3.0f;
    
    public float BrickHittedDamage = 1.0f;
    private float DamageCoefficient = 100f;

    private int gold = 0;
    private int breakBlock = 0;
    public List<Bits> BitTable = new List<Bits>();

    void Start()
    {
       
        rb = GetComponent<Rigidbody2D>();
        Vector2 diagonal = new Vector2(-2, 2).normalized;
        diagonal = InitialSpeed * diagonal;
        rb.velocity = diagonal;
    }
    private void Update()
    {
        //속도가 너무 빠르거나 느릴경우 제한.
        rb.velocity = rb.velocity.normalized * Mathf.Clamp(rb.velocity.magnitude, minSpeed, maxSpeed);
        if (rb.velocity.y == 0) rb.AddForce(0.1f * Vector3.up);
        Vector3 pos = transform.position;
        if((pos.x < -2) || (pos.x > 1.1) 
            || (pos.y < -2) || (pos.y > 2.2f)
            ) {
            transform.position = iniPos;
        }
    }
    /// <summary>
    /// 블럭에 부딪힌다면 부딪힌 블럭을 파괴 후 아이템 드랍
    /// 바닥에 떨어진 경우 체력을 줄이고 초기 위치로 돌아와 다시 발사됨.  
    /// </summary>
    /// <param name="other"></param>
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Block"))
        {
            Vector3 pos = other.transform.position;
            Instantiate(woodbreak, pos, Quaternion.identity);
            bool isBroken = other.gameObject.GetComponent<Enemytext>().TakeDamage(CalculateDamage(), pos);
            float isDropped = Random.Range(0.0f, 1.0f);
            if (isBroken)
            {
                gold += Random.Range(0, 4);
                breakBlock += 1;
                if (isDropped < BitDropRate)
                {
                    BitDrop(pos);
                }
            }
            Invoke("DestoryParticle", 0.5f);
        }
        else if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerConroller>().TakeDamage(BrickHittedDamage,false);
        }
        else if (other.gameObject.name.Equals("Bottom"))
        {
            BallHasFallen();
        }
        else if (other.gameObject.CompareTag("Boss"))
        {
            Vector3 pos = other.transform.position;
            pos.z = -1f; //보스에 글씨가 가려져서 한칸 앞으로 땡김
            Instantiate(woodbreak, pos, Quaternion.identity);
            bool isBroken = other.gameObject.GetComponent<Enemytext>().TakeDamage(CalculateDamage(), pos);
            Invoke("DestoryParticle", 0.5f);
        }


    }
    void BallHasFallen()
    {
        if (transform.parent.childCount > 1)
        {
            Destroy(gameObject);
            return;
        }
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerConroller>().BallFallen();
        float temp = rb.gravityScale;
        rb.gravityScale = 0;
        rb.velocity = Vector2.zero; 
        rb.angularVelocity = 0;
        rb.transform.position = iniPos;
        float angle = Random.Range(20, 160) * Mathf.Deg2Rad;
        Vector2 iniForce = new Vector2(Mathf.Cos(angle) ,Mathf.Sin(angle)).normalized;
        iniForce = InitialSpeed * iniForce;
        //rb.AddForce(iniForce);
        rb.velocity = iniForce;
        rb.gravityScale = temp;

    }
    void BitDrop(Vector3 pos)
    {
        Bits dropped = PlayerInfo.playerInfo.RandomPicker.GetRandomPick();
        GameObject Drop = Instantiate(dropped.gameObject, pos, Quaternion.identity) as GameObject;
        Drop.transform.localScale = new Vector3(0.2f,0.2f,0.2f);
    }

    public float CalculateDamage()
    {
        float baseDamage = rb.velocity.magnitude * rb.mass * DamageCoefficient;
        
        // Apply default damage
        float damage = baseDamage;
        
        // Apply Attack attribute of player info
        damage += PlayerInfo.playerInfo.curData.Attack;

        // Apply 치명타. 치명타 성공시 데미지 200%증가
        if (Random.value < PlayerInfo.playerInfo.curData.Critical) damage *= 2;

        // Apply 속성. 현재는 구현되어진 속성이 없으므로 Non(무) 속성 고정.
        damage *= GetDamageTypeModifier(DamageType.Non);

        return damage;
    }
    private void OnDisable()
    {
        countScore();
    }
    /// <summary>
    /// add gain gold and brokenBlock count to playerInfo.
    /// </summary>
    public void countScore()
    {
        PlayerInfo.playerInfo.curRun.coin += gold;
        PlayerInfo.playerInfo.curRun.brokenBlock = breakBlock;
    }

    /// <summary>
    /// Working on implement element(attribute) damage. 
    /// TODO : 속성별 데미지 계수 정하기.
    /// PlayerInfo 에서 현재 element설정하기.
    /// 각 속성별 특성에 맞는 공격 방식 추가.
    /// </summary>
    /// <param name="damageType"></param>
    /// <returns></returns>
    private float GetDamageTypeModifier(DamageType damageType)
    {
        // Retrieve the damage type modifier based on the specific damage type
        float damageModifier = 1f;

        switch (damageType)
        {
            case DamageType.Explosion:
                damageModifier = 1.2f;
                break;
            case DamageType.Poision:
                damageModifier = 0.8f;
                break;
            case DamageType.Dark:
                damageModifier = 1.5f;
                break;
            case DamageType.Electricity:
                damageModifier = 0.5f;
                break;
            case DamageType.Non:
                damageModifier= 1f;
                break;
                // Add more damage type cases and modifiers as needed
        }

        return damageModifier;
    }
}
