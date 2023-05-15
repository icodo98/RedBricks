using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauesMenu : MonoBehaviour
{
    private Animator animator; 

    public void Pause()
    {
       
    }

    public void Resume()
    {
       
    }
    public void backToMap(int SceneId) 
    {
     
        SceneManager.LoadScene(SceneId);
    }
     private void Awake() {
        animator = GetComponent<Animator>();
    }
    public void Close(){
        StartCoroutine(CloseAfterDelay());
    }

    private IEnumerator CloseAfterDelay()
    {
        animator.SetTrigger("close");
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
        animator.ResetTrigger("close");
    }

    private IEnumerator delayTime()
    {
        yield return new WaitForSeconds(0.7f);
    }
}
