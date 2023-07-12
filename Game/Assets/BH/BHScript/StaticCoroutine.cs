using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StaticCoroutine : MonoBehaviour
{

     public Animator transtiton;
    public float transtitonTime = 1f;
    
 private static StaticCoroutine mInstance = null;
 
    private static StaticCoroutine instance
    {
        get
        {
            if (mInstance == null)
            {
                mInstance = GameObject.FindObjectOfType(typeof(StaticCoroutine)) as StaticCoroutine;
 
                if (mInstance == null)
                {
                    mInstance = new GameObject("StaticCoroutine").AddComponent<StaticCoroutine>();
                }
            }
            return mInstance;
        }
    }
 
    void Awake()
    {
        if (mInstance == null)
        {
            mInstance = this as StaticCoroutine;
        }
    }
 
    IEnumerator LoadLevel(int scene)
    {
        transtiton.SetTrigger("Start");
        yield return new WaitForSeconds(transtitonTime);
        SceneManager.LoadScene(scene);
    }
    IEnumerator Perform(IEnumerator coroutine)
    {
        yield return StartCoroutine(coroutine);
        Die();
    }
 
    public static void DoCoroutine(int scene)
    {
         //여기서 인스턴스에 있는 코루틴이 실행될 것이다.
        instance.StartCoroutine(instance.LoadLevel(scene));    
    }
    
    void Die()
    {
            mInstance = null;
            Destroy(gameObject);
    }
 
    void OnApplicationQuit()
    {
        mInstance = null;
    }

}
