using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Relic
{
    /// <summary>
    /// ���� ����
    /// </summary>
    public class AmorRelic : Relic
    {
        public override void Power()
        {
            AddtoPlayer();
            PlayerInformation.PlayerInfo.playerInfo.curData.Amor += 5;
        }
    }

}
