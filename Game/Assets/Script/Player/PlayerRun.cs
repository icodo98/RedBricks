using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace PlayerInformation
{
    [Serializable]
    public class PlayerRun
    {
        public Dictionary<string, Bits> BitsDic = new Dictionary<string, Bits>()
        {
            {"AddAngleBit",PlayerInfo.playerInfo.bitPrefs[0].GetComponent<Bits>() },
            {"IncreBit",PlayerInfo.playerInfo.bitPrefs[1].GetComponent<Bits>() },
            {"LengthBit",PlayerInfo.playerInfo.bitPrefs[2].GetComponent<Bits>() },
            {"MaxHealBit",PlayerInfo.playerInfo.bitPrefs[3].GetComponent<Bits>() },
            {"SizeBit",PlayerInfo.playerInfo.bitPrefs[4].GetComponent<Bits>() },
            {"SpeedUpBit",PlayerInfo.playerInfo.bitPrefs[5].GetComponent<Bits>() },
            {"SubAngleBit",PlayerInfo.playerInfo.bitPrefs[6].GetComponent<Bits>() },
            {"TiltBit",PlayerInfo.playerInfo.bitPrefs[7].GetComponent<Bits>() },
            {"SizeDownBit",PlayerInfo.playerInfo.bitPrefs[8].GetComponent<Bits>() },
        };
        public List<string> bitList; 
        public List<string> relicList;
        public int HP;
        public int MaxHP;

        public PlayerRun()
        {
            bitList = new List<string>();
            relicList = new List<string>();
            MaxHP = 100;
            HP = MaxHP;
        }
    }

}