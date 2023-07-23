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
/*
        for(int i =0 ; i < 10 ; i++)
        {
        try {
            hpSlider.value = PlayerInformation.PlayerInfo.playerInfo.HP;
        }       
        catch (NullReferenceException ex) {
            Debug.Log("why Null");
        }
        }
        */
        hpSlider.interactable = false;
        
        
    }
   
    void Update()
    {

         try {
            hpSlider.value = PlayerInformation.PlayerInfo.playerInfo.HP;
        }       
        catch (NullReferenceException ex) {
            Debug.Log("why Null");
        }
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
