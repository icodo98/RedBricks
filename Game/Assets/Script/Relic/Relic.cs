using System.Linq;
using UnityEngine;
namespace Relic
{
    
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
