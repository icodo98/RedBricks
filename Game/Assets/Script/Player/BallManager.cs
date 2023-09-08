using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour, IListener
{
    private Rigidbody2D rb;
    private int _priority = 5;
    public int priority
    {
        get => _priority;
        set => _priority = value;
    }
    private Vector3 velocity;
    
    private void Start()
    {
        EventManager.Instance.AddListener(myEventType.GameOver, this);
        EventManager.Instance.AddListener(myEventType.StageClear, this);
        EventManager.Instance.AddListener(myEventType.GameResume, this);
        EventManager.Instance.AddListener(myEventType.GamePause,this);
    }
    public void OnEvent(myEventType eventType, Component Sender, object Param = null)
    {
        switch (eventType)
        {
            case myEventType.GameOver:
            case myEventType.StageClear:
                gameObject.SetActive(false);
                // gameover와 stageClear의 경우 공의 움직임을 멈춘다.
                break;
            case myEventType.GamePause:
                velocity = transform.GetChild(0).GetComponent<Rigidbody2D>().velocity;
                transform.GetChild(0).GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                break;
            case myEventType.GameResume:
                gameObject.SetActive(true);
                transform.GetChild(0).GetComponent<Rigidbody2D>().velocity = velocity;
                break;

            default: throw new System.Exception("There is a unhandled event at " + this.name);

        }
    }
}
