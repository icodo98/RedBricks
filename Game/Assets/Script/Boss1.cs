using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : MonoBehaviour, IListener
{
    public int HP;

    public int priority { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public void OnEvent(myEventType eventType, Component Sender, object Param = null)
    {
        throw new System.NotImplementedException();
    }

    private void Start()
    {
        EventManager.Instance.AddListener(myEventType.GameResume, this);
        EventManager.Instance.AddListener(myEventType.GameOver, this);
        EventManager.Instance.AddListener(myEventType.StageClear, this);
        EventManager.Instance.AddListener(myEventType.GamePause, this);
        

    }
    
}
