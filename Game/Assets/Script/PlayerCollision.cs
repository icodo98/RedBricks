using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    public float speed = 3.0f;
    public Vector3 iniPos = new Vector3(0.02f, -1.23f, 0f);
    [SerializeField]
    private float BitDropRate = 0.5f;
    [SerializeField]
    private float maxSpeed = 5.5f;

    public List<Bits> BitTable = new List<Bits>();
    public static Rito.WeightedRandomPicker<Bits> wrPicker = new Rito.WeightedRandomPicker<Bits>();

    
    /*
     * 초기 속도에 맞게 공이 출발하게 해주고, bit 아이템 드랍 테이블을 picker에 연결함.
     */

    void Start()
    {
       
        rb = GetComponent<Rigidbody2D>();
        Vector2 diagonal = new Vector2(-2, 2).normalized;
        diagonal = speed * diagonal;
        rb.velocity = diagonal;

        for (int i = 0; i < BitTable.Count; i++)
        {
            wrPicker.Add(BitTable[i], BitTable[i].Weight());
        }
    }
    private void Update()
    {
        if(rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }
    /*
     * 충돌시 동작제어. block에 부딪혔을 때와 바닥에 부딪혔을 경우로 나눠짐.
     * 블럭에 부딪힌다면 부딪힌 블럭을 파괴 후 아이템 드랍 여부를 결정
     * 바닥에 떨어진 경우 체력을 줄이고 초기 위치로 돌아와 다시 발사됨.
     */
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Block")){
            Vector3 pos = other.transform.position;
            Destroy(other.gameObject);
            float isDropped = Random.Range(0.0f,1.0f);
            if(isDropped < BitDropRate) {
                BitDrop(pos);
            }
        }
        else if (other.gameObject.name.Equals("Bottom"))
        {
            BallHasFallen();
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
        Vector2 iniForce = new Vector2(-1, 1).normalized;
        iniForce = speed * iniForce;
        //rb.AddForce(iniForce);
        rb.velocity = iniForce;
        rb.gravityScale = temp;

    }
    void BitDrop(Vector3 pos)
    {
        Bits dropped = wrPicker.GetRandomPick();
        GameObject Drop = Instantiate(dropped.gameObject, pos, Quaternion.identity) as GameObject;
    }

    
}
