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
 private PlayerInformation.PlayerInfo plin;
 public List<Bits> bBits; 
 private string FilePath;

  private PlayerInformation.PlayerData LoadData;
 private PlayerInformation.PlayerData curData;

 public void Awake()
 {
  bringBits();
   
 }
  public void bringBits()
  {
     FilePath = Application.dataPath + "/PlayerData.json";
    LoadData = PlayerInformation.PlayerDataUtils.ReadData(FilePath);
            curData = new PlayerInformation.PlayerData(LoadData);
    //bBits = 
  }
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
                break;
            case 1:
                bit1.image.color = Color.white;
                bit2.image.color = Color.green;
                bit3.image.color = Color.white;
                break;
            case 2:
                bit1.image.color = Color.white;
                bit2.image.color = Color.white;
                bit3.image.color = Color.green;
                break;
        }
    }

    
}
