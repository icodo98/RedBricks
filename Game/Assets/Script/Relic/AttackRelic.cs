using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerInformation;
namespace Relic
{
    /// <summary>
    /// curData�� ���� ���ݷ��� 15���.
    /// </summary>
    public class AttackRelic : Relic
    {
        public override void Power()
        {
            PlayerInfo.playerInfo.curData.Attack += 15;
        }
    }

}
