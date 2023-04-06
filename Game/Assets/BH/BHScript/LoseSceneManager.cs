using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseSceneManager : MonoBehaviour,IListener
{
    private void Awake()
    {
        
    }
    private void Start()
    {
        this.transform.GetChild(0).gameObject.SetActive(false);
        EventManager.Instance.AddListener(myEventType.GameOver, this);
    }
    public void OnEvent(myEventType eventType, Component Sender, object Param = null)
    {
        switch (eventType)
        {
            case myEventType.GameOver:
               this.transform.GetChild(0).gameObject.SetActive(true);
                break;

        }
    }

    public void TitleButton()
    {
        SceneManager.LoadScene(0);
    }

}

