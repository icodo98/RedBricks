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

   Loot GetItem(){
        int randomNumber = Random.Range(1,101);
        List<Loot> possibleItems = new List<Loot>();
        foreach (Loot item in lootList)
        {
            if(randomNumber <= item.dropChance)
            {
                possibleItems.Add(item);
            }
        }
        if(possibleItems.Count > 0)
        {
            Loot droppedItem = possibleItems[Random.Range(0, possibleItems.Count)];
            return droppedItem;
        }
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
        GameObject lootGameObject = Instantiate(droppedItemPrefab, spawnPosition, Quaternion.identity);
        lootGameObject.GetComponent<SpriteRenderer>().sprite =RandomItem.lootSprite;

       // float dropForce = 3f;
      //  Vector2 dropDirecetion = new Vector2(Random.Range(-1f,1f),Random.Range(-1f,1f));
      //  lootGameObject.GetComponent<Rigidbody2D>().AddForce(dropDirecetion * dropForce, ForceMode2D.Impulse);

        }

         bitName = finditems(RandomItem.lootSprite);
         if(bitName.Contains(b))
         {
              PR.BitsDic.TryGetValue(bitName, out tempIndex);
              tempGameObjectBit = indToSprite(tempIndex);
              AddBit = tempGameObjectBit.GetComponent<Bits>();
              PlayerInformation.PlayerInfo.playerInfo.bitsList.Add(AddBit);
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
            PlayerInformation.PlayerDataUtils.SaveCurData();
         }

    }

     public string finditems(Sprite img){
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
