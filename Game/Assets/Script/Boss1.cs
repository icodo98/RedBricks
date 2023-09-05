using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : MonoBehaviour, IListener
{
    public int HP;
    private int _priority = 0;
    public int priority {
        get => _priority; 
        set => _priority = value; 
    }
    public GameObject block;
    private WaitForSeconds waitFor3Seconds = new WaitForSeconds(3);
    public void OnEvent(myEventType eventType, Component Sender, object Param = null)
    {
        switch (eventType)
        {
            case myEventType.StageClear:
            case myEventType.GameOver:
            case myEventType.GamePause:
                break;
            case myEventType.GameResume:
                
            default: throw new System.Exception("There is a unhandled event at " + this.name);
        }
    }

    private void Start()
    {
        EventManager.Instance.AddListener(myEventType.GameResume, this);
        EventManager.Instance.AddListener(myEventType.GameOver, this);
        EventManager.Instance.AddListener(myEventType.StageClear, this);
        EventManager.Instance.AddListener(myEventType.GamePause, this);
        

    }
    
    IEnumerator summonBlocks()
    {
        if(block == null) yield break;
        Vector2 position = new Vector2();
        if (!checkPosition(position))
        {
            Instantiate(block, position, Quaternion.identity, this.transform);
        }
        yield return waitFor3Seconds;
    }

    private bool checkPosition(Vector2 position) {
        


        return false;
    }

}
