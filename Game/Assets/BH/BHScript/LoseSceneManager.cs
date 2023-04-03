using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseSceneManager : MonoBehaviour,IListener
{
    public void OnEvent(myEventType eventType, Component Sender, object Param = null)
    {
        switch (eventType)
        {
            case myEventType.GameOver:
                this.gameObject.SetActive(true);
                break;

        }
    }

    public void TitleButton()
    {
        SceneManager.LoadScene(0);
    }

}

