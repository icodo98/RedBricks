using PlayerInformation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPslider : MonoBehaviour
{
    public Slider hpSlider;
    public PlayerConroller player;
    void Start()
    {
        hpSlider = GetComponent<Slider>();
        player = GameObject.FindWithTag("Player").GetComponent<PlayerConroller>();
        hpSlider.minValue = 0;
    }

    // Update is called once per frame
    void Update()
    {

        hpSlider.maxValue = player.MAXHP; 
        hpSlider.value = player.HP;
        
    }
}
