using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using PlayerInformation;

public class PlayerBits : MonoBehaviour
{
    
    public List<Bits> temporalBits;

    private List<Bits> permBits;
    public GameObject maxHealBit;
    private void Start()
    {
        temporalBits = new List<Bits>();
        permBits = PlayerInfo.playerInfo.bitsList;
        foreach (Bits bits in permBits)
        {
            if (bits != null) bits.Power();
        }
        
    }
    
    public List<Bits> pickRandomBit()
    {
        temporalBits = temporalBits.Distinct<Bits>().ToList();
        if(temporalBits.Count > 0)
        {
            if (temporalBits.Contains(PlayerInfo.playerInfo.bitPrefs[3].GetComponent<Bits>()))
            {
                temporalBits.Remove(PlayerInfo.playerInfo.bitPrefs[3].GetComponent<Bits>());
            }
        }
        if(temporalBits.Count > 3)
        {
            List<Bits> returnList = new List<Bits>();
            for (int i = 0; i < 3; i++)
            {
                int j = Random.Range(0, temporalBits.Count);
                returnList.Add(temporalBits[j]);
                temporalBits.RemoveAt(j);
            }
            return returnList;
        }
        else
        {
            return temporalBits;
        }
    }
   
}
