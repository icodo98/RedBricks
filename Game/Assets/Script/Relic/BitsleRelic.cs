using PlayerInformation;
namespace Relic
{
    /// <summary>
    /// make player select the bit after stage clear.
    /// </summary>
    public class BitsleRelic : Relic
    {
        public override void Power()
        {
            PlayerInfo.playerInfo.curData.EnableSelection= true; 
        }
    }
}

