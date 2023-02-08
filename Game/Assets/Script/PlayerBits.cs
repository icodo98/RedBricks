using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBits : MonoBehaviour
{
    // Start is called before the first frame update
    public List<string> temporalBits;

    private List<string> permBits;
    
    private void Start()
    {
        temporalBits = new List<string>();
    }
}
