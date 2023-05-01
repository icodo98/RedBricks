using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blockbreak : MonoBehaviour
{
    public ParticleSystem woodbreak;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    private void OnColliderEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Ball")
        {
            Instantiate(woodbreak, transform.position, Quaternion.identity);
            
        }
    }
}
