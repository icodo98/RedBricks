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
public GameObject c;
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
         c.SetActive(false);
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

public void animatNoBit(){
  if(bBits.Count==0){
  NoBit.SetTrigger("noBit");
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



        //// remove bit
[System.Serializable] public class SelectedBit
    {
        public Sprite Image;
    }
    
    public List<SelectedBit> SelctedBitsList;

 public void seletedBtn()
 {
    int tempIndex;
    GameObject tempGameObjectBit;
    Bits RemoveBit;
    string bitNmae = null;
     for(int i =0; i < sBits.Count; i++)
        {
            if(sBits[i].IsSetceted)
            {
                Addimage(sBits[i].Image);
                break;
            }
        }
      bitNmae = findBits(SelctedBitsList[0].Image);
      PR.BitsDic.TryGetValue(bitNmae, out tempIndex);
      tempGameObjectBit = indToSprite(tempIndex);
      RemoveBit = tempGameObjectBit.GetComponent<Bits>();
      PlayerInformation.PlayerInfo.playerInfo.bitsList.Remove(RemoveBit);
 }
 void Addimage(Sprite img) 
    {
        if(SelctedBitsList == null)
        SelctedBitsList = new List<SelectedBit>();
        SelectedBit sb = new SelectedBit(){Image = img};
        SelctedBitsList.Add(sb);

    }

  public string findBits(Sprite img){
    string spn = img.name;
    string bitName = null;
    switch (spn)
    {
      case "Brown": bitName = "AddAngleBit";
        break;
      case "Red": bitName = "HealBit";
        break;
        case "Aquamarin": bitName = "IncreBit";
        break;
        case "Blue": bitName = "LengthBit" ;
        break;
        case "Lilac": bitName = "MaxHealBit";
        break;
        case "Dark_Blue": bitName = "SizeBit";
        break;
        case "Yellow": bitName = "SizeDownBit";
        break;
        case "Emerald": bitName = "SpeedUpBit";
        break;
        case "Green": bitName = "SubAngleBit";
        break;
        case "Orange": bitName = "TiltBit";
        break;
      
    }
    return bitName;
  }
    ////


///// HP //////

  public void regenHP()
  {
    SaveFullHPJSON();
   
  }
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
         PlayerInformation.PlayerInfo.playerInfo.HP = save.HP;
        Debug.Log("Save");
    }
    //Load Secne//
    public void ToMap()
   {
        StartCoroutine(LoadLevel(2));
   }
    
   
    public Animator transtiton;
    public float transtitonTime = 1f;
    
    
    IEnumerator LoadLevel(int scene)
    {
        transtiton.SetTrigger("Start");
        yield return new WaitForSeconds(transtitonTime);
        SceneManager.LoadScene(scene);
    }
}
