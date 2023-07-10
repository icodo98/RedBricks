using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
public class MapHPUI : MonoBehaviour
{
    float HP;
    public GameObject HPText;
        private void Start() {
            HP = PlayerInformation.PlayerInfo.playerInfo.HP;
            HPText.GetComponent<Text>().text = HP.ToString();
        }
}
