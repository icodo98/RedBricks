using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System;
using PlayerInformation;

public class MapinfoUI : MonoBehaviour
{
    public Slider hpSlider;
    private float HpminValue = 0;
    private float MaxHP;
    
    public Text MapCoin;
   
    void Start()
    {
        MaxHP = PlayerInformation.PlayerInfo.playerInfo.MaxHP;
        hpSlider.maxValue = MaxHP;
        hpSlider.minValue = HpminValue;
        hpSlider.interactable = false;
        
    }
   
    void Update()
    {
            UpdateCoin();
            hpSlider.value = PlayerInformation.PlayerInfo.playerInfo.HP;
    }
    public void UpdateCoin()
        {
            
            MapCoin.text = PlayerInformation.PlayerInfo.playerInfo.curRun.coin.ToString();
            
        }
}
