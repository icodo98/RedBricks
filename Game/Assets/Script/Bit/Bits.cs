using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class Bits : MonoBehaviour, IListener
{
    public float FallingSpeed;
    public double weight;
    private int _priority = 0;
    public int priority { 
        get => _priority;
        set => _priority = value;
    }

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
        GameObject blocks = GameObject.Find("Blocks");
        if(blocks != null)
        {
            FallingSpeed = blocks.GetComponent<BlockController>().fallingSpeed;

        }
        FallingSpeed += 0.25f;
        EventManager.Instance.AddListener(myEventType.GameOver, this);
    }
    private void Update()
    {
        transform.Translate(0, -FallingSpeed * Time.deltaTime, 0);
    }
    public abstract void Power();
    public abstract double Weight();

    public void OnEvent(myEventType eventType, Component Sender, object Param = null)
    {
        switch (eventType)
        {
            case myEventType.GameEnd:
                break;
            case myEventType.GameStart:
                break;
            case myEventType.GamePause:
                break;
            case myEventType.GameResume:
                break;
            case myEventType.GameOver:
                Destroy(gameObject);
                break;
            case myEventType.StageClear:
                break;
            case myEventType.HealthChange:
                break;
            default:
                throw new System.Exception("There is unhandled event at " + this.name);
        }
    }
}
