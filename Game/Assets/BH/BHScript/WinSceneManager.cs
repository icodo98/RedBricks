using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinSceneManager : MonoBehaviour, IListener
{

    public int priority { 
        get => 1; 
        set => priority = value; 
    }
    private void Start()
    {
        EventManager.Instance.AddListener(myEventType.StageClear, this);
        StartCoroutine(testc());
        
    }
    IEnumerator testc()
    {
        yield return new WaitForSeconds(2f);
        EventManager.Instance.PostNotification(myEventType.StageClear,this) ;

    [SerializeField]
    private Button bit1;
    [SerializeField]
    private Button bit2;
    [SerializeField]
    private Button bit3;
    /*
    private void OnEnable()
     {
        switch (WinSceneBitSelect.bitselcet)
        {
            case Bitselcet.Bit1:
                bit1.image.color = Color.green;
                bit2.image.color = Color.white;
                bit3.image.color = Color.white;
                break;
            case Bitselcet.Bit2:
                bit1.image.color = Color.white;
                bit2.image.color = Color.green;
                bit3.image.color = Color.white;
                break;
            case Bitselcet.Bit3:
                bit1.image.color = Color.white;
                bit2.image.color = Color.white;
                bit3.image.color = Color.green;
                break;
        }
    */

    public void SelectedBit(int bitselcet)
    {
        WinSceneBitSelect.bitselcet = (Bitselcet)bitselcet;
        switch (WinSceneBitSelect.bitselcet)
        {
            case Bitselcet.Bit1:
                bit1.image.color = Color.green;
                bit2.image.color = Color.white;
                bit3.image.color = Color.white;
                break;
            case Bitselcet.Bit2:
                bit1.image.color = Color.white;
                bit2.image.color = Color.green;
                bit3.image.color = Color.white;
                break;
            case Bitselcet.Bit3:
                bit1.image.color = Color.white;
                bit2.image.color = Color.white;
                bit3.image.color = Color.green;
                break;
        }
    }
    public void TitleButton()
    {
        SceneManager.LoadScene(0);
    }
    public void selectBit(List<Bits> bits)
    {
        GameObject bit1 = transform.GetChild(0).GetChild(6).GetChild(2).gameObject;
        GameObject bit2 = transform.GetChild(0).GetChild(6).GetChild(3).gameObject;
        GameObject bit3 = transform.GetChild(0).GetChild(6).GetChild(4).gameObject;
        bit1.GetComponent<Image>().sprite = bits[0].GetComponent<SpriteRenderer>().sprite;
        bit2.GetComponent<Image>().sprite = bits[1].GetComponent<SpriteRenderer>().sprite;
        bit3.GetComponent<Image>().sprite = bits[2].GetComponent<SpriteRenderer>().sprite;
    }

    public void OnEvent(myEventType eventType, Component Sender, object Param = null)
    {
        switch (eventType)
        {
            case myEventType.StageClear:
                this.transform.GetChild(0).gameObject.SetActive(true);
                break;
            default: throw new System.Exception("There is a unhandled event at " + this.name);
        }
    }

    public void MapButton()
    {
        SceneManager.LoadScene(2);
    }

}

