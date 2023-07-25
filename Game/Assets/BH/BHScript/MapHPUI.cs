using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System;
public class MapHPUI : MonoBehaviour
{
    public Slider hpSlider;
    private float HpminValue = 0;

    
   
    void Start()
    {
        hpSlider.interactable = false;
        
        
    }
   
    void Update()
    {

            hpSlider.value = PlayerInformation.PlayerInfo.playerInfo.HP;
    }
}
