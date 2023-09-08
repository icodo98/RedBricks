using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerInformation;

public class retryControl : MonoBehaviour
{
    private void OnEnable()
    {
        if (PlayerInfo.playerInfo.curData.curResurrection > 0)
        {
            transform.GetChild(4).gameObject.SetActive(true);

        }
        else
        {
            transform.GetChild(4).gameObject.SetActive(false);

        }
        
    }
}
