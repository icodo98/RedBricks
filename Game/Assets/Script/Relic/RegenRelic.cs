using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Relic
{
    /// <summary>
    /// 체력 증가량이 3초당 1로 증가.
    /// </summary>
    public class RegenRelic : Relic
    {
        public override void Power()
        {
            AddtoPlayer();
            PlayerInformation.PlayerInfo.playerInfo.curData.RegenHealth += 1.0f;
        }
    }

}
