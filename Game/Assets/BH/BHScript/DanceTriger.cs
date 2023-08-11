using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanceTriger : MonoBehaviour
{
    public  Animator Dance;


   public void StartDance()
   {
        Dance.SetTrigger("Dance");
   }
   public void testButton()
   {
     Debug.Log("1");
   }
}
