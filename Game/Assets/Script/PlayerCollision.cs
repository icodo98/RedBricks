using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    public float speed = 3.0f;
    [SerializeField]
    private float BitDropRate = 0.5f;

    public List<Bits> BitTable = new List<Bits>();
    public static Rito.WeightedRandomPicker<Bits> wrPicker = new Rito.WeightedRandomPicker<Bits>();
    void Start()

    {
      rb = GetComponent<Rigidbody2D>();
        Vector2 diagonal = new Vector2(-2, 2).normalized;
        diagonal = speed * diagonal;
        //rb.AddForce(diagonal);
        rb.velocity = diagonal;
        for (int i = 0; i < BitTable.Count; i++)
        {
            wrPicker.Add(BitTable[i], BitTable[i].Weight()) ;
        }
        
    }
    
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
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerConroller>().BallFallen();
        float temp = rb.gravityScale;
        rb.gravityScale = 0;
        rb.velocity = Vector2.zero; 
        rb.angularVelocity = 0;
        rb.transform.position = new Vector3(0.02f, -1.23f, 0f);
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
