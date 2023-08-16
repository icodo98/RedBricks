using Relic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Relic
{
    public class ResurrectionRelic : Relic
    {
        /// <summary>
        /// 부활용 relic. 현재 부활기회를 하나 늘려줌.
        /// </summary>
        public override void Power()
        {
            AddtoPlayer();
            PlayerInformation.PlayerInfo.playerInfo.curData.curResurrection += 1;
        }

    }
}

