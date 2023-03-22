using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBits : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Bits> temporalBits;

    private List<Bits> permBits;
    
    private void Start()
    {
        temporalBits = new List<Bits>();
        
    }
}
