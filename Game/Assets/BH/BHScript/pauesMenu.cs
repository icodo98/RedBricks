using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauesMenu : MonoBehaviour, IListener
{
    private Animator animator;
    private int _priority = 1;
    public int priority
    {
        get => _priority;
        set => _priority = value;
    }
    private void Start()
    {
        EventManager.Instance.AddListener(myEventType.GameOver, this);
        EventManager.Instance.AddListener(myEventType.StageClear, this);
        EventManager.Instance.AddListener(myEventType.GameResume, this);

    }
    private void OnEnable()
    {
        transform.SetAsLastSibling();
        Debug.Log("this onEnable function is called.");
    }
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
        EventManager.Instance.PostNotification(myEventType.GameResume, this);
        Time.timeScale = 1;
        AudioManager.Instance.musicSource.Play();
        StartCoroutine(CloseAfterDelay());
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

    public void OnEvent(myEventType eventType, Component Sender, object Param = null)
    {
        switch (eventType)
        {
            case myEventType.GameEnd:
                break;
            case myEventType.GameStart:
                break;
            case myEventType.GamePause:
                break;
            case myEventType.GameResume:
                gameObject.SetActive(true);
                break;
            case myEventType.GameOver:
            case myEventType.StageClear:
                gameObject.SetActive(false);
                break;
            default:
                throw new System.Exception("There is a unhandled event at " + this.name);
        }
    }
}
