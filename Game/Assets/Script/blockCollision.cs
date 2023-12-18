using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockCollision : MonoBehaviour
{
    private int FreezeStack = 0;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Bottom"))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerConroller>().TakeDamage(50, false);
            Destroy(this.gameObject);
        }
        else if(collision.gameObject.CompareTag("Player"))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerConroller>().TakeDamage(25, false);
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.CompareTag("Ball"))
        {
            if(collision.gameObject.GetComponent<PlayerCollision>().FreezeBit) 
            {
                FreezeStack++;
                if(FreezeStack > 5) {
                    GetComponent<ElementalPower>().WaterPower(collision);
                    FreezeStack = 0;
                }
            }
        }

    }
}
