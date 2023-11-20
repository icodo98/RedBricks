using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlay : MonoBehaviour
{
   public Animator Ani;
   public GameObject Nextob;
   public GameObject curob;

   public void Next(){
    Ani.SetTrigger("Next");
     StartCoroutine(WaitForIt());

   }

    IEnumerator WaitForIt()
 {
   yield return new WaitForSeconds(0.8f);
     curob.SetActive(false);
     Nextob.SetActive(true);
 }
}
