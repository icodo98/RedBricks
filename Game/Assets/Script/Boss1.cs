using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : MonoBehaviour, IListener
{
    public int MaxHP;
    private int _priority = 0;
    public int priority {
        get => _priority; 
        set => _priority = value; 
    }
    public GameObject block;
    private WaitForSeconds waitFor3Seconds = new (1.8f);
    [SerializeField]
    private Vector3 startPoint = new Vector3(-0.85f, -0.2f, 0f);

    [SerializeField]
    private Vector3 endPoint = new Vector3(0.8f, 1.9f, 0f);
    private int i;

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
        GetComponent<Enemytext>().HP = MaxHP;
        StartCoroutine(summonBlocks());
    }
    /// <summary>
    /// 잡몹을 소환하는 코루틴. 잡몹이 소환될 위치를 특정하고, 그 위치에 블럭을 소환한다.
    /// </summary>
    /// <returns></returns>
    IEnumerator summonBlocks()
    {
        while(true)
        {
            Vector3[] position = newPoisition();

            foreach (Vector3 item in position)
            {
                if (!checkPosition(item)) continue;
                GameObject MobBlock = Instantiate(block, item, Quaternion.identity, this.transform);
                MobBlock.transform.localScale = new Vector3(0.8f, 0.2f, 1f);
            }
           // yield return null;
              yield return waitFor3Seconds;
        }

    }
    /// <summary>
    /// 인수로 받은 위치에 collider가 존재하는지 여부르 확인하는 코드. 없다면 true, 있으면 false
    /// </summary>
    /// <param name="position"></param>
    /// <returns>비었으면 true</returns>
    private bool checkPosition(Vector2 position) {

        Collider2D result =  Physics2D.OverlapBox(position,new Vector2(0.57f,0.14f) ,0);
        if (result == null)
        {
            return true;
        }

        else
        {
            return false;
        }

    }
    private Vector3[] newPoisition()
    {
        int arraySize = Random.Range(3,7);
        Vector3[] returnArray = new Vector3[arraySize];
        while (i < arraySize)
        {
            float x = Random.Range(startPoint.x, endPoint.x);
            float y = Random.Range(startPoint.y, endPoint.y);
            
            returnArray[i] = new Vector3(x,y,0);
            if (checkPosition(returnArray[i])) i++;

        }
        return returnArray;
    }
    private void OnDisable()
    {
        EventManager.Instance.PostNotification(myEventType.StageClear,null);
    }
}
