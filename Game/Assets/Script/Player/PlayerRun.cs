using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace PlayerInformation
{
    [Serializable]
    public class PlayerRun
    {
        public Dictionary<string, int> BitsDic = new Dictionary<string, int>()
        {
            {"AddAngleBit", 0},
            {"IncreBit",    1},
            {"LengthBit",   2},
            {"MaxHealBit",  3},
            {"SizeBit",     4},
            {"SpeedUpBit",  5},
            {"SubAngleBit", 6},
            {"TiltBit",     7},
            {"SizeDownBit", 8},
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
        public Bits indToBits(int index)
        {
            return PlayerInfo.playerInfo.bitPrefs[index].GetComponent<Bits>();
        }
    }

}