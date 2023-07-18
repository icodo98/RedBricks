using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerInformation;
namespace Relic
{
    /// <summary>
    /// curData의 현재 공격력을 15상승.
    /// </summary>
    public class AttackRelic : Relic
    {
        public override void Power()
        {
            PlayerInfo.playerInfo.curData.Attack += 15;
        }
    }

}
