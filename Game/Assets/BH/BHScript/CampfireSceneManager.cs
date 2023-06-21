using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class CampfireSceneManager : MonoBehaviour
{
  [SerializeField]
    private Button bit1;
    [SerializeField]
    private Button bit2;
    [SerializeField]
    private Button bit3;
 public List<Bits> bBits; 
 private int sbit;

  public void displaybits()
  {
    int rndnum1 = Random.Range(0, bBits.Count);
    int rndnum2 = Random.Range(0, bBits.Count);
    int rndnum3 = Random.Range(0, bBits.Count);
    Sprite b1 = bBits[rndnum1].GetComponent<SpriteRenderer>().sprite; 
    Sprite b2 = bBits[rndnum2].GetComponent<SpriteRenderer>().sprite; 
    Sprite b3 = bBits[rndnum3].GetComponent<SpriteRenderer>().sprite; 
    int bC = bBits.Count;
    switch(bC)
    {
      case 0 :
                Destroy(bit1);
                Destroy(bit2);
                Destroy(bit3);
      break;
      case 1 :
                Destroy(bit1);
                  bit2.image.sprite = b2 ;
                Destroy(bit3);
              
      break;
      case 2 :
                bit1.image.sprite = b1;
                Destroy(bit2);
                bit3.image.sprite = b3;
      break;
      default :
                bit1.image.sprite = b1;
                bit2.image.sprite = b2 ;
                bit3.image.sprite = b3;

      break;
      
    }    
  }
  public void RemoveBit()
  {
    
  }

  
  public void Regeneration()
  {
   // SaveFullHPJSON();
  }

  public void ToMap()
  {
    SceneManager.LoadScene(2);
  }

    
  public void SelectedBit(int bitselcet)
    {
        
        switch (bitselcet)
        {
            case 0:
                bit1.image.color = Color.green;
                bit2.image.color = Color.white;
                bit3.image.color = Color.white;
                sbit = 0;
                break;
            case 1:
                bit1.image.color = Color.white;
                bit2.image.color = Color.green;
                bit3.image.color = Color.white;
                sbit = 1;
                break;
            case 2:
                bit1.image.color = Color.white;
                bit2.image.color = Color.white;
                bit3.image.color = Color.green;
                sbit = 2;
                break;
        }
    }
///// HP //////
  private PlayerInformation.PlayerRun saveGameObject()
    {
        PlayerInformation.PlayerRun save = new PlayerInformation.PlayerRun();
        save.HP = save.MaxHP;
    
        return save;
    }

    private void SaveFullHPJSON()
    {
        PlayerInformation.PlayerRun save = saveGameObject();
        string JsonString = JsonUtility.ToJson(save);
        StreamWriter sw = new StreamWriter(Application.dataPath + "/PlayerInfo.json");
        sw.Write(JsonString);
        sw.Close();
        Debug.Log("Save");
    }
    
}
