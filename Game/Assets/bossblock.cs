using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bossblock : MonoBehaviour
{
    public Slider Timer;
    public float fallingSpeed;
    private void Start()
    {
        Timer.value = Timer.maxValue;
    }
    // Update is called once per frame
    void Update()
    {
       
        if (Timer.value <= 0)
        {
            Timer.gameObject.SetActive(false);
            transform.Translate(0, -fallingSpeed * Time.deltaTime, 0);

        }
        else
        {
            Timer.value -= Time.deltaTime;
        }

    }
}
