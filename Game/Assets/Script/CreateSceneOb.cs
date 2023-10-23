using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSceneOb : CreateScene
{
    public GameObject Block;
    public GameObject Obstacle;
    public float obstacleRate = 0.15f;
    private void Update()
    {
        float i = Random.value;
        if(i < obstacleRate)
        {
            prefabBlock = Block;
        }
        else
        {
            prefabBlock = Obstacle;
        }
    }
}
