using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestBackToMap : MonoBehaviour
{
    // Start is called before the first frame update
    public void backToMap() 
    {
        SceneManager.LoadScene(2);
    }
}
