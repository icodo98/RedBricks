using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockCollision : MonoBehaviour
{
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

    }
}
