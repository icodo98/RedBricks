using PlayerInformation;
namespace Relic
{
    /// <summary>
    /// make player select the bit after stage clear.
    /// </summary>
    public class BitsleRelic : Relic
    {
        // ToDo winUI���� bit�� ���� ��Ʈ���� Ȯ���� ���� ����.
        public override void Power()
        {
            PlayerInfo.playerInfo.curData.EnableSelection= true; 
        }
    }
}

