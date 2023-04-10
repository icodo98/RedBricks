using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerInfo : MonoBehaviour, IListener
{
    public static PlayerInfo playerInfo;

    public List<Bits> bitsList;

    private int _priority = 0;
    public int priority
    {
        get => _priority;
        set => _priority = value;
    }

    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (playerInfo == null)
        {
            playerInfo = this;
        }else if (playerInfo != this)
        {
            Destroy(gameObject);
        }
    }
    public void Start()
    {
        EventManager.Instance.AddListener(myEventType.StageClear, playerInfo);
    }

    /*
     * stageClear시 발생할 이벤트. 영구 bit을 추가하여야함.
     */
    public void OnEvent(myEventType eventType, Component Sender, object Param = null)
    {
       switch (eventType)
        {
            case myEventType.StageClear:
                Bits[] temp = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBits>().temporalBits.ToArray();
                if (temp.Length == 0) break;
                int i = Random.Range(0, temp.Length);
                Bits aBits = GetComponent(temp[i].GetType()) as Bits;
                bitsList.Add(aBits);
                break;
        }
    }
 }


