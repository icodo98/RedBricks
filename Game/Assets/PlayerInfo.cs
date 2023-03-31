using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public static PlayerInfo playerInfo;

    public List<Bits> bitsList;


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

}
