using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class lightController : MonoBehaviour,IListener
{
    private int V = 1;
    public Light2D Light2D;

    public int priority { 
        get => V;
        set => V = value; 
    }

    public void OnEvent(myEventType eventType, Component Sender, object Param = null)
    {
        switch (eventType)
        {
            case myEventType.GameOver:
                
            case myEventType.StageClear: 
                
            case myEventType.GamePause:
                Light2D.intensity = 1;
                break;
            case myEventType.GameResume:
                Light2D.intensity = 0;
                break;
            
            default: throw new Exception("There is unhandled event!");
        }
    }

    private void Start()
    {
        EventManager.Instance.AddListener(myEventType.GameOver, this);
        EventManager.Instance.AddListener(myEventType.GamePause, this);
        EventManager.Instance.AddListener(myEventType.GameResume, this);
        EventManager.Instance.AddListener(myEventType.StageClear, this);
    }
}
