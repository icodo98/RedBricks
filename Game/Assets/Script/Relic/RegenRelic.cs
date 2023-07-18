using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Relic
{
    /// <summary>
    /// ü�� �������� 3�ʴ� 1�� ����.
    /// </summary>
    public class RegenRelic : Relic
    {
        public override void Power()
        {
            PlayerInformation.PlayerInfo.playerInfo.curRun.relicList.Add(prefab);
            PlayerInformation.PlayerInfo.playerInfo.curData.RegenHealth += 1.0f;
        }
    }

}
