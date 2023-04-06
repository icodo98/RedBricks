using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerInfo : MonoBehaviour, IListener
{
    public static PlayerInfo playerInfo;

    public List<Bits> bitsList;
    
    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (playerInfo == null)
        {
            playerInfo = this;
            EventManager.Instance.AddListener(myEventType.StageClear, playerInfo);
        }else if (playerInfo != this)
        {
            Destroy(gameObject);
        }
    }
    /*
     * ���߿� �����. getcomponent�� playerinfo�� �ִ� ������ �ҷ���. �̸� �̿��� ���� �ٲ�
     * bit������ ������.
     */
    public void Update()
    {
        Debug.Log(bitsList.Count);
        Bits nBits = GetComponent(bitsList[0].GetType()) as Bits;
        bitsList.Add(nBits);
        

        bitsList.Add((Bits)nBits);
    }
    /*
     * stageClear�� �߻��� �̺�Ʈ. ���� bit�� �߰��Ͽ�����.
     */
    public void OnEvent(myEventType eventType, Component Sender, object Param = null)
    {
       switch (eventType)
        {
            case myEventType.StageClear:
                Bits[] temp = Sender.GetComponent<PlayerBits>().temporalBits.ToArray();
                int i = Random.Range(0, temp.Length);
                bitsList.Add(temp[i]);
                
                _ = Sender.GetComponent<PlayerBits>().temporalBits;
                break;
        }
    }
 }


