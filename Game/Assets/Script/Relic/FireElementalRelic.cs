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

        public static void Fire(Collision2D other)
        {
            int i = 0;
            float startTime = Time.time;

            while (i < 5)
            {
                if(Time.time - startTime >= 1f)
                {
                    other.gameObject.GetComponent<Enemytext>().TakeDamage(1, other.transform.position);
                    i++;
                    startTime = Time.time;

                }

            }
        }
    }
}

