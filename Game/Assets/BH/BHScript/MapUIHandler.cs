using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapUIHandler : MonoBehaviour
{
    public int stageNum;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    public void backToMain()
    {
        SceneManager.LoadScene(0);
    }
    
    public void backToMap()
    {
        SceneManager.LoadScene(1);
    }

    public void StartStageScene()
    {
        SceneManager.LoadScene("Stage" + stageNum.ToString());
    }
}
