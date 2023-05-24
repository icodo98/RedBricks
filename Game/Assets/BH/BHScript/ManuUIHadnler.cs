using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManuUIHadnler : MonoBehaviour
{
    private Animator animator; //setting open animator
    public Animator transtiton;
    public float transtitonTime = 1f;
    
    
    public void ToMapScene()
    {
    
        StartCoroutine(LoadLevel(1));
        
    }

    public void ToReinforceScene()
    {
        StartCoroutine(LoadLevel(5));
    }

    IEnumerator LoadLevel(int scene)
    {
        transtiton.SetTrigger("Start");
        yield return new WaitForSeconds(transtitonTime);
        SceneManager.LoadScene(scene);
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
}
