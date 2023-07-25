using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Relic
{
    /// <summary>
    /// 
    /// </summary>
    public class PowerRelic : Relic
    {
        public override void Power()
        {
            AddtoPlayer();
        }
    }

}
