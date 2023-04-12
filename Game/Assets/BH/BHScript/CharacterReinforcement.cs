using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterReinforcement : MonoBehaviour
{
    public PermanentReinforcement BallDamage;
    public PermanentReinforcement hardness;
    public PermanentReinforcement BarLength;
    public PermanentReinforcement Speed;
    public PermanentReinforcement revive;



    public int currentBallDamage;
    public int currenthardness;
    public int currentBarLength;
    public int currentSpeed;
    public int currentRevive;

    public void UpgradeBallDamge()
    {
        currentBallDamage += BallDamage.GetValue() + 1;
    }
    public void UpgradeHardness()
    {
       currenthardness += hardness.GetValue() + 1;
    }

    public void UpgradeBarLegth()
    {
        currentBarLength += BarLength.GetValue() + 1;
    }

    public void UpgradeSpeed()
    {
        currentSpeed+= Speed.GetValue() + 1;
    }

    public void UpgradeRecice()
    {
        currentRevive = 1;
    }


}
