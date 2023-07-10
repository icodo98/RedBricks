using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class ShopGetPurchased : MonoBehaviour
{

    #region Singlton:ShopGetPurchased

    public static ShopGetPurchased instance;

     void Awake() 
        {
            if(instance == null)
            instance = this;
            else
            Destroy(gameObject);
        }
    #endregion

        Button buyBtn;

   [System.Serializable] public class Purchased
    {
        public Sprite Image;
    }
    
    public List<Purchased> PurchasedList;


    public PlayerInformation.PlayerRun PR;
    public void GetAvailablePurchased()
    {
        for(int i =0; i < ShopingsecenManager.instance.ShopItemList.Count; i++)
        {
            if(ShopingsecenManager.instance.ShopItemList[i].IsPurchased)
            {
                Addimage(ShopingsecenManager.instance.ShopItemList[i].Image);
            }
        }
    }

    void Addimage(Sprite img) 
    {
        if(PurchasedList == null)
        PurchasedList = new List<Purchased>();
        Purchased Pc = new Purchased(){Image = img};
        PurchasedList.Add(Pc);

    }
    
    public void confirmButton()
    {
        for(int i =0; i < 6; i++){
        buyBtn = ShopingsecenManager.instance.ShopView.GetChild(i).GetChild(2).GetComponent<Button>();
        buyBtn.interactable = false;
    }
    SaveByCoinJSON();

        string bitName;
        int tempIndex;
        GameObject tempGameObjectBit;
        Bits AddBit;
        for(int i = 0; i < PurchasedList.Count ;i++){
        bitName = findBits(PurchasedList[i].Image);
      PR.BitsDic.TryGetValue(bitName, out tempIndex);
      tempGameObjectBit = indToSprite(tempIndex);
      AddBit = tempGameObjectBit.GetComponent<Bits>();
      PlayerInformation.PlayerInfo.playerInfo.bitsList.Add(AddBit);
        }
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
     public GameObject indToSprite(int index)
        {
            return PlayerInformation.PlayerInfo.playerInfo.bitPrefs[index];
        }

 private CoinJson saveGameObject()
    {
        CoinJson save = new CoinJson();
        save.Coin = ShopCoin.Instance.Coins;
    
        return save;
    }

    private void SaveByCoinJSON()
    {
        CoinJson save = saveGameObject();
        string JsonString = JsonUtility.ToJson(save);
        StreamWriter sw = new StreamWriter(Application.dataPath + "/CoinJson.text");
        sw.Write(JsonString);
        sw.Close();
        Debug.Log("Save");
    }

     private void LoadByCoinJSON()
    {
        if(File.Exists(Application.dataPath + "/CoinJson.text"))
        {
            StreamReader sr = new StreamReader(Application.dataPath + "/CoinJson.text");
            string JsonString = sr.ReadToEnd();
            sr.Close();
            CoinJson save =JsonUtility.FromJson<CoinJson>(JsonString);
            Debug.Log("LOADED");

        ////
       ShopCoin.Instance.Coins = save.Coin;

        
        }
        else
        {
            Debug.Log("NOT FOUND SAVE FILE");
        }
    }
}
