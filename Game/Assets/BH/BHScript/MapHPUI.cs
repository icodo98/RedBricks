using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
public class MapHPUI : MonoBehaviour
{
    public Slider hpSlider;
    private float HpminValue = 0;
  
    void Start()
    {
        hpSlider = GetComponent<Slider>();
        hpSlider.minValue = HpminValue;
        hpSlider.maxValue = PlayerInformation.PlayerInfo.playerInfo.MaxHP; 
        hpSlider.value = PlayerInformation.PlayerInfo.playerInfo.HP;
    }

    // Update is called once per frame


    /*
    float HP;
    public GameObject HPText;
        public void ShowHP() {
            HP = PlayerInformation.PlayerInfo.playerInfo.HP;
            HPText.GetComponent<Text>().text = HP.ToString();
        }
        */
}
