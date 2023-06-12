using System.Linq;
using UnityEngine;
namespace Relic
{
   /// <summary>
   /// Reinforce the player permanently for this run.
   /// It has prefab of its own so that can be added to playerInfo.
   /// Relic itself doesn't control the other objects, it only notifies.
   /// 
   /// </summary>
    public abstract class Relic : MonoBehaviour
    {
        public GameObject prefab;
        public abstract void Power();

        public void AddtoPlayer()
        {
            if(prefab != null)
            {
                PlayerInformation.PlayerInfo.playerInfo.Relic.Add(prefab);

            }
        }
        
    }

}
