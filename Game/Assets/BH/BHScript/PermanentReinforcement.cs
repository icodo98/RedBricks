using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PermanentReinforcement
{
    [SerializeField]
   public int baseValue = 0;

   public int GetValue()
   {
    return baseValue;

   }

}
