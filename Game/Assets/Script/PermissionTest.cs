using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.SceneManagement;

public class PermissionTest : MonoBehaviour
{

    private Vector3 pos;
    public GameObject sceneObj;
    private Camera[] cams;
    private Camera mainCam;
    public void showMap()
    {
        pauesMenu a = new pauesMenu();
        a.Pause();
        sceneObj.SetActive(false);
        mainCam = Camera.main;
        pos = mainCam.transform.position;
        mainCam.transform.position = new Vector3(0, 0, -10);
        StartCoroutine(AsyncLoad());
        
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
        SceneManager.UnloadSceneAsync(2);
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(3));
        mainCam.transform.position = pos;
        sceneObj.SetActive(true);
        pauesMenu a = new pauesMenu();
        a.Resume();
    }
}
