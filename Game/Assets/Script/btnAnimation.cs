using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class btnAnimation : MonoBehaviour
{
    public Button btn1;

    private void Start()
    {
        btn1 = GetComponent<Button>();
    }
    public void AddAnimator(GameObject goAni)
    {
        btn1.onClick.AddListener (delegate { goAni.GetComponent<Animator>().SetTrigger("Dance"); });
    }
}
