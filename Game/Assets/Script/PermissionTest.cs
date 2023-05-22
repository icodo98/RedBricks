using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.SceneManagement;

public class PermissionTest : MonoBehaviour
{

    private Vector3 pos;
    public GameObject sceneObj;
    public Camera[] cams;
    private Camera mainCam;
    public void showMap()
    {
        pauesMenu a = new pauesMenu();
        a.Pause();
        cams[0].enabled = false;
        cams[1].enabled = true;
        sceneObj.SetActive(true);
        //StartCoroutine(AsyncLoad());
        
    }
    IEnumerator AsyncLoad()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(2, LoadSceneMode.Additive);

        while (!asyncLoad.isDone) {
            yield return null;
        }
    }

    public void returnMap()
    {
        //SceneManager.UnloadSceneAsync(2);
        //SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(3));
        cams[1].enabled= false;
        cams[0].enabled = true;
        sceneObj.SetActive(false);
        pauesMenu a = new pauesMenu();
        a.Resume();
    }
}
