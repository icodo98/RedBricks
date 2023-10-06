using System;
using System.Collections;
using System.Collections.Generic;
using Relic;
using UnityEngine;

public class LootBag : MonoBehaviour
{
    public PlayerInformation.PlayerRun PR;
    public GameObject droppedItemPrefab;
    public List<Loot> lootList = new List<Loot>();
    // Start is called before the first frame update
    public GameObject AddRelic;
    public GameObject AttackRelic;
    public GameObject bitselRelic;
    public GameObject RegenRelic;
    public GameObject ResurrectionRelic;
    public GameObject AmorRelic;

    public GameObject nothing;

   Loot GetItem(){
        
        List<Loot> possibleItems = new List<Loot>();
        foreach (Loot item in lootList)
        {
            int randomNumber = UnityEngine.Random.Range(1,101);
            if(randomNumber <= item.dropChance)
            {
                possibleItems.Add(item);
            }
        }
        if(possibleItems.Count > 0)
        {
            Loot droppedItem = possibleItems[UnityEngine.Random.Range(0, possibleItems.Count)];
            return droppedItem;
        }
        
            nothing.SetActive(true);
            gameObject.SetActive(false);
            Debug.Log("No loot deroped");
            return null;
        
    }
    public void InstantiateLoot(Vector3 spawnPosition)
    {
        string bitName;
        int tempIndex;
        GameObject tempGameObjectBit;
        Bits AddBit;
        Loot RandomItem = GetItem();
        string b = "Bit";
        if(RandomItem != null)
        {
        GameObject lootGameObject = Instantiate(droppedItemPrefab, spawnPosition , Quaternion.identity);
        lootGameObject.GetComponent<SpriteRenderer>().sprite =RandomItem.lootSprite;
        }
    
         bitName = findloot(RandomItem.lootSprite.name);
         if(bitName.Contains(b))
         {
            PR.BitsDic.TryGetValue(bitName, out tempIndex);
            tempGameObjectBit = indToSprite(tempIndex);
            AddBit = tempGameObjectBit.GetComponent<Bits>();
            PlayerInformation.PlayerInfo.playerInfo.addParmentBit(AddBit);
        //     PlayerInformation.PlayerInfo.playerInfo.bitsList.Add(AddBit);

            PlayerInformation.PlayerDataUtils.SavePlayerInfo();
        }
        else
        {
            switch (bitName)
            {

                case "AddBallRelic": AddRelic.GetComponent<AddBallRelic>().Power();
                break;
                case "AttackRelic": AttackRelic.GetComponent<AttackRelic>().Power();
                break;
                case "B1itSelRelic": bitselRelic.GetComponent<BitselRelic>().Power();
                break;
                case "RegenRelic": RegenRelic.GetComponent<RegenRelic>().Power();
                break;
                case "ResurrectionRelic": ResurrectionRelic.GetComponent<ResurrectionRelic>().Power();
                break;
                case "AmorRelic": AmorRelic.GetComponent<AmorRelic>().Power();
                break;
       
            }
            PlayerInformation.PlayerInfo.playerInfo.ParmentSavePalyerInfo();
         }

    }

     public string findloot(String lootName){
    string bitName = null;
    switch (lootName)
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
        case "AddRelic": bitName = "AddBallRelic";
        break;
        case "OneHandedSword_Icon3": bitName = "AttackRelic";
        break;
        case "Bitsel": bitName = "B1itSelRelic";
        break;
        case "Regenpng": bitName = "RegenRelic";
        break;
        case "cross1282": bitName = "ResurrectionRelic";
        break;
        case "shield128": bitName = "AmorRelic";
        break;
      
    }
    return bitName;
  }
     public GameObject indToSprite(int index)
        {
            return PlayerInformation.PlayerInfo.playerInfo.bitPrefs[index];
        }


}
