using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class obeliskSceneManager : MonoBehaviour
{
    public Animator animator; 

     public void Open(){
        StartCoroutine(openChest());
    }
    private IEnumerator openChest()
    {
        animator.SetTrigger("open");
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
        animator.ResetTrigger("open");
    }

}
