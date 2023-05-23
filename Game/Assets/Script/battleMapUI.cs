using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.SceneManagement;

public class battleMapUI : MonoBehaviour
{
    public GameObject sceneObj;
    public Camera[] cams;
    public void showMap()
    {
        cams[0].enabled = false;
        cams[1].enabled = true;
        sceneObj.SetActive(true);
        
    }
    public void returnMap()
    {
        cams[1].enabled= false;
        cams[0].enabled = true;
        sceneObj.SetActive(false);
    }
}
