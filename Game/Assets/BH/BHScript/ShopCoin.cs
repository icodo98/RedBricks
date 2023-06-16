using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopCoin : MonoBehaviour
{
  #region SIngletion:ShopCoin

  public static ShopCoin Instance;

    void Awake() {
    if(Instance == null){
        Instance = this;
            }else{
                Destroy(gameObject);
            }
  }
  #endregion

  public int Coins;

  public void UesCoins (int amount)
  {
    Coins -= amount;
  }
  public bool HasEnoughCoins (int amount)
  {
    return (Coins >= amount);
  }
}
