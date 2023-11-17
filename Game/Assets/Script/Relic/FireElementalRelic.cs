using PlayerInformation;
using System.Collections;
using UnityEngine;

namespace Relic
{
    public class FireElementalRelic : Relic
    {
        /// <summary>
        /// change damage type to Fire elemental. 
        /// dot dealing 
        /// </summary>
        public override void Power()
        {
            AddtoPlayer();
            PlayerInfo.playerInfo.curData.ElementDamage = DamageType.Fire;

        }

    }
}

