using PlayerInformation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPslider : MonoBehaviour
{
    public Slider hpSlider;
    public GameObject player;
    void Start()
    {
        hpSlider = GetComponent<Slider>();
        //player = GameObject.FindWithTag("Player").GetComponent<PlayerConroller>();
        
        hpSlider.minValue = 0;
    }

    // Update is called once per frame
    void Update()
    {

        switch (player.tag)
        {
            case "Player":
                hpSlider.maxValue = player.GetComponent<PlayerConroller>().MAXHP;
                hpSlider.value = player.GetComponent<PlayerConroller>().HP;
                break;
            case "Boss":
                hpSlider.maxValue = player.GetComponent<Boss1>().MaxHP;
                hpSlider.value = player.GetComponent<Enemytext>().HP;
                break;

            default:
                hpSlider.maxValue = 0;
                hpSlider.value = 0;
                break;
        }

    }
}
