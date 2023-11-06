using UnityEngine;
using PlayerInformation;

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

    public int gold = 0;
    public int breakBlock = 0;

    void Start()
    {
       
        rb = GetComponent<Rigidbody2D>();
        Vector2 diagonal = new Vector2(-2, 2).normalized;
        if(PlayerInfo.playerInfo.curData.Speed > 0)
        {
            InitialSpeed = InitialSpeed * (1 + PlayerInfo.playerInfo.curData.Speed * 0.1f);
        }
        diagonal = InitialSpeed * diagonal;
        rb.velocity = diagonal;
    }
    private void Update()
    {
        //�ӵ��� �ʹ� �����ų� ������� ����.
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
    /// ������ �ε����ٸ� �ε��� ������ �ı� �� ������ ���
    /// �ٴڿ� ������ ��� ü���� ���̰� �ʱ� ��ġ�� ���ƿ� �ٽ� �߻��.  
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
                //gold += Random.Range(0, 4);
                //breakBlock += 1;
                PlayerInfo.playerInfo.curRun.coin += Random.Range(0, 4);
                PlayerInfo.playerInfo.curRun.brokenBlock += 1;
                PlayerInfo.playerInfo.curRun.totalCoins += PlayerInfo.playerInfo.curRun.coin;


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
            pos.z = -1f; //������ �۾��� �������� ��ĭ ������ ����
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

        // Apply ġ��Ÿ. ġ��Ÿ ������ ������ 200%����
        if (Random.value < PlayerInfo.playerInfo.curData.Critical) damage *= 2;

        // Apply �Ӽ�. ����� �����Ǿ��� �Ӽ��� �����Ƿ� Non(��) �Ӽ� ����.
        damage *= GetDamageTypeModifier(DamageType.Non);

        return damage;
    }
    private void OnDisable()
    {
       // countScore();
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
    /// TODO : �Ӽ��� ������ ��� ���ϱ�.
    /// PlayerInfo ���� ���� element�����ϱ�.
    /// �� �Ӽ��� Ư���� �´� ���� ��� �߰�.
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
