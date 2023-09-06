using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class ShopingsecenManager : MonoBehaviour
{
    #region Singlton:ShopingsecenManager

    public static ShopingsecenManager instance;

     void Awake() 
        {
            if(instance == null)
            instance = this;
            else
            Destroy(gameObject);
        }
    #endregion

    public List<ShopItem> ShopItemsentireList;

   [System.Serializable] public class ShopItem
   {
    public Sprite Image;
    public int Price;
    public bool IsPurchased = false;
   }

   
   
   public List<ShopItem> ShopItemList;
   [SerializeField] Animator NoCoinsAnim;
   [SerializeField] Text coinText;
    
    GameObject ItemTemplate;
   GameObject g;
   public Transform ShopView;

    Button buyBtn;
    
   void Start()
   {
    randomItemPutList();
    ItemTemplate = ShopView.GetChild(0).gameObject;
    int len =ShopItemList.Count;
    for(int i =0; i <len; i++)
    {
        g = Instantiate ( ItemTemplate, ShopView);
        g.transform.GetChild (0).GetComponent<Image>().sprite = ShopItemList[i].Image;
        g.transform.GetChild (1).GetComponent<Text>().text = ShopItemList[i].Price.ToString();
        buyBtn = g.transform.GetChild (2).GetComponent<Button>();
       // buyBtn.interactable = !ShopItemList[i].IsPurchased;
        buyBtn.AddEventListener(i,onShopItemBtnClicked);
    }
    Destroy(ItemTemplate);
    CoinUpdate();
    SetCoinsUI();
  
   }
   
   void onShopItemBtnClicked(int itemIndex){
       buyBtn = ShopView.GetChild(itemIndex).GetChild(2).GetComponent<Button>();
      // buyBtn.interactable = false;
      if(ShopItemList[itemIndex].IsPurchased){
        ShopCoin.Instance.getBackCoins(ShopItemList[itemIndex].Price);
        buyBtn.transform.GetChild(0).GetComponent<Text>().text = "Buy";
        ShopItemList [itemIndex].IsPurchased = false;
        SetCoinsUI();
      }
      else if (!ShopItemList[itemIndex].IsPurchased)
      {
         if(ShopCoin.Instance.HasEnoughCoins(ShopItemList[itemIndex].Price)){
            buyBtn.transform.GetChild(0).GetComponent<Text>().text = "Purchased";
            ShopCoin.Instance.UesCoins(ShopItemList[itemIndex].Price);
            Debug.Log(itemIndex);
            ShopItemList [itemIndex].IsPurchased = true;
          }else{
            NoCoinsAnim.SetTrigger("noMoney");
            Debug.Log("Not enough Coin");
           }
          SetCoinsUI();
      }
   }
   /////////
   void SetCoinsUI()
   {
    coinText.text = ShopCoin.Instance.Coins.ToString();
   }

   void CoinUpdate()
   {
     ShopCoin.Instance.Coins = PlayerInformation.PlayerInfo.playerInfo.curRun.coin;
   }
   /////////randomItem///////
    private void randomItemPutList()
    {
         List<int> intList = new List<int>();

         int ranNum = Random.Range(0,ShopItemsentireList.Count);
               for(int i =0; i < 6;){
              if (intList.Contains(ranNum))
              {
                ranNum = Random.Range(0, ShopItemsentireList.Count);
              }
              else
              {
                intList.Add(ranNum);
                i++;
              }
        }
        for(int i =0; i < 6; i++){
      
        ShopItemList.Add(ShopItemsentireList[intList[i]]);
        }
    }
   ////// LoadScene//////
    public void ToMain()
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
   
    public void testSetCoin()
    {
        ShopCoin.Instance.Coins = 400;
        SetCoinsUI();
    }
}

