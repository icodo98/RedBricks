using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemytext : MonoBehaviour
{
    public GameObject hudDamageText;
  
    
    public void TakeDamage(int damage,Vector3 hudPos)
    {
        GameObject hudText = Instantiate(hudDamageText);
        hudText.transform.position = hudPos;
        hudText.GetComponent<DamageText>().damage =damage;
    }
}
