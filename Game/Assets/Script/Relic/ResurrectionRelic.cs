using Relic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Relic
{
    public class ResurrectionRelic : Relic
    {
        /// <summary>
        /// ��Ȱ�� relic. ���� ��Ȱ��ȸ�� �ϳ� �÷���.
        /// </summary>
        public override void Power()
        {
            AddtoPlayer();
            PlayerInformation.PlayerInfo.playerInfo.curData.curResurrection += 1;
        }

    }
}

