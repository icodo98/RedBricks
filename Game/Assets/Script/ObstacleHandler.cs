using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleHandler: MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag.Equals("Wall"))
        {
            Destroy(this.gameObject);
        }
    }
}
