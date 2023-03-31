using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManuUIHadnler : MonoBehaviour
{
    private Animator animator; //setting open animator
    public Animator transtiton;
    public float transtitonTime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
    public void ToMapScene()
    {
    
        StartCoroutine(LoadLevel());
        
    }

    IEnumerator LoadLevel()
    {
        transtiton.SetTrigger("Start");
        yield return new WaitForSeconds(transtitonTime);
        SceneManager.LoadScene(1);
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
