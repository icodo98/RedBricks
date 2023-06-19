using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinSceneManager : MonoBehaviour, IListener
{

    public int priority { 
        get => 1; 
        set => priority = value; 
    }
    [SerializeField]
    private Button bit1;
    [SerializeField]
    private Button bit2;
    [SerializeField]
    private Button bit3;

    private List<Bits> tempBits;
    public int selectedBit = 0;
    private void Start()
    {
        EventManager.Instance.AddListener(myEventType.StageClear, this);
    }
    public void SelectedBit(int bitselcet)
    {
        WinSceneBitSelect.bitselcet = (Bitselcet)bitselcet;
        switch (WinSceneBitSelect.bitselcet)
        {
            case Bitselcet.Bit1:
                selectedBit = 1;
                bit1.image.color = Color.green;
                bit2.image.color = Color.white;
                bit3.image.color = Color.white;
                break;
            case Bitselcet.Bit2:
                selectedBit = 2;
                bit1.image.color = Color.white;
                bit2.image.color = Color.green;
                bit3.image.color = Color.white;
                break;
            case Bitselcet.Bit3:
                selectedBit = 3;
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
        tempBits = bits;
        GameObject bit1 = transform.GetChild(0).GetChild(6).GetChild(2).gameObject;
        GameObject bit2 = transform.GetChild(0).GetChild(6).GetChild(3).gameObject;
        GameObject bit3 = transform.GetChild(0).GetChild(6).GetChild(4).gameObject;
        switch (bits.Count)
        {
            case 3:
                bit1.GetComponent<Image>().sprite = bits[0].GetComponent<SpriteRenderer>().sprite;
                bit2.GetComponent<Image>().sprite = bits[1].GetComponent<SpriteRenderer>().sprite;
                bit3.GetComponent<Image>().sprite = bits[2].GetComponent<SpriteRenderer>().sprite;
                break;
            case 2:
                bit1.GetComponent<Image>().sprite = bits[0].GetComponent<SpriteRenderer>().sprite;
                bit2.SetActive(false);
                bit3.GetComponent<Image>().sprite = bits[1].GetComponent<SpriteRenderer>().sprite;

                break;
            case 1:
                bit1.SetActive(false);
                bit2.GetComponent<Image>().sprite = bits[0].GetComponent<SpriteRenderer>().sprite;
                bit3.SetActive(false);
                break;
            default:
                selectedBit = 4;
                break;
        }
    }

    public void OnEvent(myEventType eventType, Component Sender, object Param = null)
    {
        switch (eventType)
        {
            case myEventType.StageClear:
                PlayerPrefs.SetInt("StageClear", 1);
                this.transform.GetChild(0).gameObject.SetActive(true);
                break;
            default: throw new System.Exception("There is a unhandled event at " + this.name);
        }
    }

    public void MapButton()
    {
        SceneManager.LoadScene(2);
    }
    public void addPram()
    {
        PlayerInformation.PlayerInfo.playerInfo.addParmentBit(tempBits, selectedBit);
    }
}

