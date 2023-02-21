using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bits : MonoBehaviour
{
    public float FallingSpeed;
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerBits>().temporalBits.Add(name);
        }
        else if (other.CompareTag("Bottom"))
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        transform.Translate(0, -FallingSpeed * Time.deltaTime, 0);
    }
    public abstract void Power();
}
