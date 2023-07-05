using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class CampfireSceneManager : MonoBehaviour
{////tset///

public Animator NoBit;
public PlayerInformation.PlayerRun PR;

[System.Serializable]public class campfirebit
   {
   public Sprite Image;

   public bool IsSetceted = false;

   }

public List<Bits> bBits; 
public List<campfirebit> sBits; 

public List<campfirebit> presBits; 

public GameObject b;

GameObject ItemTemplate;
   GameObject g;
   public Transform bitView;

   Button selectBtn;
private void Start() {
   bBits = PlayerInformation.PlayerInfo.playerInfo.bitsList;
  convertBitsImage();
  randomItemPutList();
  ItemTemplate = bitView.GetChild(0).gameObject;
  if(bBits.Count == 0)
      {
        b.SetActive(false);
        NoBit.SetTrigger("nunoBit");
      }
      else{
    int len = sBits.Count;
    for(int i =0; i <len; i++)
    {
        g = Instantiate ( ItemTemplate, bitView);
        g.transform.GetChild (0).GetComponent<Image>().sprite = sBits[i].Image;
        selectBtn = g.transform.GetChild (1).GetComponent<Button>();
      
        selectBtn.AddEventListener(i,onItemBtnClicked);
    }
    Destroy(ItemTemplate);
      }
}

void onItemBtnClicked(int itemIndex){
        selectBtn = bitView.GetChild(itemIndex).GetChild(1).GetComponent<Button>();
     
         selectBtn.transform.GetChild(0).GetComponent<Text>().text = "Selected";
        Debug.Log(itemIndex);
        sBits [itemIndex].IsSetceted = true;
        for(int i =0; i < 3 ; i++){
          bitView.GetChild(i).GetChild(1).GetComponent<Button>().interactable = false;
        }        
      }

       private void randomItemPutList()
    {
         List<int> intList = new List<int>();
      if(bBits.Count == 0)
      {
        //
      }
      else
      {
         int ranNum = Random.Range(0,bBits.Count);
               for(int i =0; i < 3;){
              
                intList.Add(ranNum);
                i++;
              
        }
        for(int i =0; i < 3; i++){
      
        sBits.Add(presBits[intList[i]]);
        }
      }
    }
    campfirebit tempCamBit = new();
    public void convertBitsImage()
    {
      Sprite spr;
      int tempIndex;
      GameObject tempBitspr;

      if(bBits.Count == 0)
      {
        //
      }
      else{
      for(int i=0; i < bBits.Count ;i++)
      {
       
      
        string tempString = bBits[i].name;
        Debug.Log(tempString);
        PR.BitsDic.TryGetValue(tempString, out tempIndex);
        Debug.Log(tempIndex);
        tempBitspr = indToSprite(tempIndex);
        Debug.Log(tempBitspr);
        spr = tempBitspr.gameObject.GetComponent<SpriteRenderer>().sprite;
        Debug.Log(spr);
        tempCamBit.Image = spr;
        presBits.Add(tempCamBit);
        
      }
      }
    }
   
   public GameObject indToSprite(int index)
        {
            return PlayerInformation.PlayerInfo.playerInfo.bitPrefs[index];
        }

  public void CreatePreBit()
  {

  }
/////
  /*
  [SerializeField]
    private Button bit1;
    [SerializeField]
    private Button bit2;
    [SerializeField]
    private Button bit3;
 public List<Bits> bBits; 
 private int sbit;

public GameObject PI;

  public void displaybits()
  {
    bBits = PI.GetComponent<PlayerInformation.PlayerInfo>().bitsList;
    
    int rndnum1 = Random.Range(0, bBits.Count);
    int rndnum2 = Random.Range(0, bBits.Count);
    int rndnum3 = Random.Range(0, bBits.Count);
    if (true)
    
      {
         bit1.SetActive(false);
          bit2.SetActive(false);
           bit3.SetActive(false);
      }
    
    Sprite b1 = bBits[rndnum1].GetComponent<SpriteRenderer>().sprite; 
    Sprite b2 = bBits[rndnum2].GetComponent<SpriteRenderer>().sprite; 
    Sprite b3 = bBits[rndnum3].GetComponent<SpriteRenderer>().sprite; 
    int bC = bBits.Count;
    switch(bC)
    {
      case 0 :
                bit1.image.color=new Color(0,0,0,0);
                bit2.image.color=new Color(0,0,0,0);
                bit3.image.color=new Color(0,0,0,0);
      break;
      case 1 :
                bit1.image.color=new Color(0,0,0,0);
                  bit2.image.sprite = b2 ;
                bit3.image.color=new Color(0,0,0,0);
              
      break;
      case 2 :
                bit1.image.sprite = b1;
                bit2.image.color=new Color(0,0,0,0);
                bit3.image.sprite = b3;
      break;
      default :
                bit1.image.sprite = b1;
                bit2.image.sprite = b2 ;
                bit3.image.sprite = b3;

      break;
      
    }    
  }*/

  
  public void Regeneration()
  {
    SaveFullHPJSON();
    PlayerInformation.PlayerInfo.playerInfo.LoadPlayerInfo();
  }

  public void ToMap()
  {
    SceneManager.LoadScene(2);
  }

 /*   
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
    */
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
