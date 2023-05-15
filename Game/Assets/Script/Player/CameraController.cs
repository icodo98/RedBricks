using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour,IListener
{
    private int _priority = 1;
    public int priority { get => _priority;
        set => _priority = value; }

    public void OnEvent(myEventType eventType, Component Sender, object Param = null)
    {
        switch (eventType)
        {
            case myEventType.GameEnd:
                break;
            case myEventType.GameStart:
                break;
            case myEventType.GamePause:
                GetComponent<AudioSource>().Pause();
                break;
            case myEventType.GameResume:
                GetComponent<AudioSource>().Play();
                break;
            case myEventType.GameOver:
                break;
            case myEventType.StageClear:
                break;
            case myEventType.HealthChange:
                break;
            default:
                throw new System.Exception("There is a unhandled event at " + this.name);
                break;
        }
    }
    public void Start()
    {
        EventManager.Instance.AddListener(myEventType.GamePause, this);
        EventManager.Instance.AddListener(myEventType.GameResume, this);
    }

}
