using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
}
}
