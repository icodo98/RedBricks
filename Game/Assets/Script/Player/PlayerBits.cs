using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using PlayerInformation;

public class PlayerBits : MonoBehaviour
{
    
    public List<Bits> temporalBits;
    [SerializeField]
    private List<Bits> permBits;
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
        // MaxHeal 과 Heal bit은 영구 bit에 추가되면 안되므로 제거해줌.
        if(temporalBits.Count > 0)
        {
            if (temporalBits.Contains(PlayerInfo.playerInfo.bitPrefs[1].GetComponent<Bits>()))
            {
                temporalBits.Remove(PlayerInfo.playerInfo.bitPrefs[1].GetComponent<Bits>());
            }
            if (temporalBits.Contains(PlayerInfo.playerInfo.bitPrefs[0].GetComponent<Bits>()))
            {
                temporalBits.Remove(PlayerInfo.playerInfo.bitPrefs[0].GetComponent<Bits>());
            }
        }
        List<Bits> returnList = new List<Bits>();
        if (temporalBits.Count > 3)
        {
            for (int i = 0; i < 3; i++)
            {
                int j = Random.Range(0, temporalBits.Count);
                returnList.Add(temporalBits[j]);
                temporalBits.RemoveAt(j);
                
            }
        }
        else
        {
            foreach (Bits bits in temporalBits)
            {
                returnList.Add(bits);
            }
        }
        
        if (PlayerInfo.playerInfo.curData.EnableSelection == false) return returnList.Take(1).ToList();
        else return returnList;
    }
   
}
