using PlayerInformation;
namespace Relic
{
    /// <summary>
    /// make player select the bit after stage clear.
    /// </summary>
    public class BitsleRelic : Relic
    {
        // ToDo winUI에서 bit을 고르는 파트에서 확인후 고르게 설정.
        public override void Power()
        {
            PlayerInfo.playerInfo.curData.EnableSelection= true; 
        }
    }
}

