using PlasticGui;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSecne : MonoBehaviour
{
    [SerializeField]
    private Vector3 startPoint = new Vector3(1.45f, 0.45f, 0f);

    [SerializeField]
    private Vector3 endPoint = new Vector3(3f, 1.45f, 0f);

    
    void Start()
    {
        GameObject Blocks = new GameObject("Blocks");
        int cols = Random.Range(4, 7);
        int rows = Random.Range(1, 4);

        float h = endPoint.y - startPoint.y;
        float w = endPoint.x - startPoint.x;
        h = h / cols;
        w = w / rows;

        int[] colPoint = new int[cols];
        for (int i =0; i < cols; i++)
        {
            
        }

    }

}
