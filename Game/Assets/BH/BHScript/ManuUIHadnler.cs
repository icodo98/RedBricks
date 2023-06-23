using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ManuUIHadnler : MonoBehaviour
{
    private Animator animator; //setting open animator
    public Animator transtiton;
    public float transtitonTime = 1f;
    public Button loadbutton;

    private     int GO;
    
    public void ToMapScene()
    {
    
        StartCoroutine(LoadLevel(2));
        
    }

    public void ToMapSeceneNewGame()
    {
        PlayerPrefs.SetInt("GameOver",1);
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
        PlayerPrefs.GetInt("GameOver",GO);
        Debug.Log(GO.ToString());
            animator = GetComponent<Animator>();
         if (PlayerPrefs.GetInt("GameOver")==1){
            loadbutton.gameObject.SetActive(false);
         }
    }
    private void Start() {
    
        PlayerPrefs.GetInt("GameOver",GO);
        Debug.Log(GO.ToString());

        if (PlayerPrefs.GetInt("GameOver")==1){
            loadbutton.gameObject.SetActive(false);
         }
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
