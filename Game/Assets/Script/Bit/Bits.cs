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
            Debug.Log("Name of this bit is " + this.name);
            List<GameObject> prefabs =  PlayerInformation.PlayerInfo.playerInfo.bitPrefs;
            int i = 0;
            foreach (GameObject item in prefabs)
            {
                if (item.GetComponent<Bits>().GetType().Equals(this.GetType())) break;
                i++;
            }
            other.gameObject.GetComponent<PlayerBits>().temporalBits.Add(prefabs[i].GetComponent<Bits>()) ;
            other.gameObject.GetComponent<PlayerBits>().temporalBits.Last<Bits>().Power();
            Destroy(gameObject);
        }
        else if (other.name == "Bottom")
        {
            Destroy(gameObject);
        }
    }
    private void OnEnable()
    {
        FallingSpeed = GameObject.Find("Blocks").GetComponent<BlockController>().fallingSpeed + 0.2f;
    }
    private void Update()
    {
        transform.Translate(0, -FallingSpeed * Time.deltaTime, 0);
    }
    public abstract void Power();
    public abstract double Weight();

}
