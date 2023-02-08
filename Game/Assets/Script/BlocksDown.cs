using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocksDown : MonoBehaviour
{
    // Start is called before the first frame update
    public float fallingSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0,-fallingSpeed*Time.deltaTime,0);
    }
}
