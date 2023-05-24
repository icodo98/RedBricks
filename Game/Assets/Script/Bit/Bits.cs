using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class Bits : MonoBehaviour
{
    public float FallingSpeed;
    public double weight;
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            //other.gameObject.GetComponent<PlayerBits>().temporalBits.Add(this);
            Debug.Log("bits meet player!");
            other.gameObject.GetComponent<PlayerBits>().temporalBits.Add(GetComponent<Bits>());
            other.gameObject.GetComponent<PlayerBits>().temporalBits.Last<Bits>().Power();
            Destroy(gameObject);
        }
        else if (other.name == "Bottom")
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        transform.Translate(0, -FallingSpeed * Time.deltaTime, 0);
    }
    public abstract void Power();
    public abstract double Weight();

}
