using PlayerInformation;
namespace Relic
{
    /// <summary>
    /// Add another ball when the battle starts.
    /// </summary>
    public class AddBallRelic : Relic
    {
        // Implemented PlayerConroller.cs adding code.
        
        public override void Power()
        {
            PlayerInfo.playerInfo.curData.AddBall = true;
        }
    }
   
}

