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
        //this.enabled = false;
        //this.transform.localScale = Vector3.zero;
        this.transform.GetChild(0).gameObject.SetActive(false);
        EventManager.Instance.AddListener(myEventType.GameOver, this);
    }
    public void OnEvent(myEventType eventType, Component Sender, object Param = null)
    {
        switch (eventType)
        {
            case myEventType.GameOver:
                //this.transform.localScale = new Vector3(1,1,1);
                //this.enabled = true;
                this.transform.GetChild(0).gameObject.SetActive(true);
                break;

        }
    }

    public void TitleButton()
    {
        SceneManager.LoadScene(0);
    }

}

