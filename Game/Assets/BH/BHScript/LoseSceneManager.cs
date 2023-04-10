using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseSceneManager : MonoBehaviour,IListener
{
    private int _priority = 1;
    public int priority { 
        get => _priority; 
        set => _priority = value; 
    }

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
            default: throw new System.Exception("There is a unhandled event at " + this.name);
        }
    }

    public void TitleButton()
    {
        SceneManager.LoadScene(0);
    }

    public int CompareTo(IListener other)
    {
        throw new System.NotImplementedException();
    }
}

