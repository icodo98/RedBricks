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
     * 나중에 지울거. getcomponent로 playerinfo에 있는 정보를 불러옴. 이를 이용해 씬이 바뀌어도
     * bit정보를 저장함.
     */
    public void Update()
    {
        Debug.Log(bitsList.Count);
        Bits nBits = GetComponent(bitsList[0].GetType()) as Bits;
        bitsList.Add(nBits);
        

        bitsList.Add((Bits)nBits);
    }
    /*
     * stageClear시 발생할 이벤트. 영구 bit을 추가하여야함.
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


