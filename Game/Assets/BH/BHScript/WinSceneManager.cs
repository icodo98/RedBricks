using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class WinSceneManager : MonoBehaviour
{
    [SerializeField]
    private Button bit1;
    [SerializeField]
    private Button bit2;
    [SerializeField]
    private Button bit3;
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
    }

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

    public void MapButton()
    {
        SceneManager.LoadScene(2);
    }

}

