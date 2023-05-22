using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauesMenu : MonoBehaviour
{
    private Animator animator; 

    public void Pause()
    {
        AudioManager.Instance.musicSource.Stop();
        EventManager.Instance.PostNotification(myEventType.GamePause, this);
        Time.timeScale = 0;
    }
     private void Awake() {
        animator = GetComponent<Animator>();
    }
    public void Resume(){
      //  StartCoroutine(CloseAfterDelay());
        EventManager.Instance.PostNotification(myEventType.GameResume, this);
        Time.timeScale = 1;
        AudioManager.Instance.musicSource.Play();
    }

    private IEnumerator CloseAfterDelay()
    {
        animator.SetTrigger("close");
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
        animator.ResetTrigger("close");
    }
    public void ToMain()
    {
        SceneManager.LoadScene(0);
        EventManager.Instance.PostNotification(myEventType.GameResume, this);
        Time.timeScale = 1;
    }

}
