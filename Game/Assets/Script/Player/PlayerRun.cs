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
            {"MaxHealBit",  0},
            {"HealBit",     1},
            {"AddAngleBit", 2},
            {"IncreBit",    3},
            {"LengthBit",   4},
            {"SizeBit",     5},
            {"SpeedUpBit",  6},
            {"SubAngleBit", 7},
            {"TiltBit",     8},
            {"SizeDownBit", 9}
        };

        public Dictionary<string, int> RelicDic = new Dictionary<string, int>()
        {
            {"AddBallRelic", 0 },
            {"AttackRelic", 1 },
            {"BitselRelic", 2 },
            {"PowerRelic", 3 },
            {"RegenRelic", 4 },
            {"ResurrectionRelic", 5 }

        };
        public List<string> bitList; 
        public List<string> relicList;
        public float HP;
        public int MaxHP;
        public int coin;
        public int brokenBlock;

        public PlayerRun()
        {
            bitList = new List<string>();
            relicList = new List<string>();
            MaxHP = 100;
            HP = (float) MaxHP;
            coin = 0;
            brokenBlock = 0;
        }
        public Bits indToBits(int index)
        {
            return PlayerInfo.playerInfo.bitPrefs[index].GetComponent<Bits>();
        }
    }

}