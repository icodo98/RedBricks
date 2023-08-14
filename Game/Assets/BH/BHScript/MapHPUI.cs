using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System;
using PlayerInformation;

public class MapHPUI : MonoBehaviour
{
    public Slider hpSlider;
    private float HpminValue = 0;
    private float MaxHP;
    public GameObject Playerinfo;
    private PlayerInfo PI;
    
   
    void Start()
    {
        MaxHP = PlayerInformation.PlayerInfo.playerInfo.MaxHP;
        hpSlider.maxValue = MaxHP;
        hpSlider.minValue = HpminValue;
        hpSlider.interactable = false;
        PI = Playerinfo.GetComponent<PlayerInfo>();
        
    }
   
    void Update()
    {

            hpSlider.value = PI.HP;
    }
}
