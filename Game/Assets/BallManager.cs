using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour, IListener
{
    private Rigidbody2D rb;
    private int _priority = 0;
    public int priority
    {
        get => _priority;
        set => _priority = value;
    }
    private void Start()
    {
        EventManager.Instance.AddListener(myEventType.GameOver, this);
        EventManager.Instance.AddListener(myEventType.StageClear, this);
    }
    public void OnEvent(myEventType eventType, Component Sender, object Param = null)
    {
        switch (eventType)
        {
            case myEventType.GameOver:
            case myEventType.StageClear:
                // gameover와 stageClear의 경우 공의 움직임을 멈춘다.
                foreach (Transform Child in transform)
                {
                    rb = Child.GetComponent<Rigidbody2D>();
                    rb.gravityScale = 0f;
                    rb.velocity = Vector2.zero;
                }
                break;
            default: throw new System.Exception("There is a unhandled event at " + this.name);

        }
    }
}
