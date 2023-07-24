using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour,IListener
{
    // Start is called before the first frame update
    public float fallingSpeed;
    public bool blCount = false;
    public bool blLeft = false;
    private float _fallingSpeed;

    private int _priority = 0;
    public int priority
    {
        get => _priority;
        set => _priority = value;
    }

    private void Start()
    {
        EventManager.Instance.AddListener(myEventType.GameResume, this);
        EventManager.Instance.AddListener(myEventType.GameOver, this);
        EventManager.Instance.AddListener(myEventType.StageClear, this);
        EventManager.Instance.AddListener(myEventType.GamePause, this);
        StartCoroutine(StageClear());

    }
    public void OnEvent(myEventType eventType, Component Sender, object Param = null)
    {
        switch (eventType)
        {
            case myEventType.StageClear:
            case myEventType.GameOver:
            case myEventType.GamePause:
                _fallingSpeed = fallingSpeed;
                fallingSpeed = 0;
                break;
            case myEventType.GameResume:
                fallingSpeed = _fallingSpeed;
                break;
            default: throw new System.Exception("There is a unhandled event at " + this.name);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(0,-fallingSpeed*Time.deltaTime,0);
        
    }
    IEnumerator StageClear()
    {
        while (true)
        {
            blCount = (transform.childCount > 0) ? false : true;
            blLeft = (GetComponent<CreateScene>().leftBlock > 0) ? false : true;

            if (blCount && blLeft)
            {
                List<Bits> bits = new List<Bits>();
                EventManager.Instance.PostNotification(myEventType.StageClear, this, bits);
                yield break;
            }
           yield return null;
        }
    }
 }
