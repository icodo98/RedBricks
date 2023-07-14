using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
public class MapHPUI : MonoBehaviour
{
    public Slider hpSlider;
  
    void Start()
    {
        hpSlider = GetComponent<Slider>();
        hpSlider.minValue = 0;
    }

    // Update is called once per frame
    void Update()
    {

        hpSlider.maxValue = PlayerInformation.PlayerInfo.playerInfo.MaxHP; 
        hpSlider.value = PlayerInformation.PlayerInfo.playerInfo.HP;
        
    }

    /*
    float HP;
    public GameObject HPText;
        public void ShowHP() {
            HP = PlayerInformation.PlayerInfo.playerInfo.HP;
            HPText.GetComponent<Text>().text = HP.ToString();
        }
        */
}
