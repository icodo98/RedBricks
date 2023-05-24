using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemytext : MonoBehaviour
{
    public GameObject hudDamageText;
    public int HP = 5;
    
    public bool TakeDamage(float damage,Vector3 hudPos)
    {
        int normalizedDamage;

        // Apply Amor. ����� block�� �ƸӰ� ���� �����Ƿ� 1�� ����. ���� ������ Ȥ�� ������ �����ʿ�.
        damage -= 1f;

        // �Ҽ��� ����.
        normalizedDamage = Mathf.FloorToInt(damage);
        HP -= normalizedDamage;

        DisplayDamage(normalizedDamage, hudPos);
        if(HP < 0) { 
            Destroy(this.gameObject);
            return true;
        }
        return false;
    }
    private void DisplayDamage(int damage, Vector3 hudPos)
    {
        GameObject hudText = Instantiate(hudDamageText);
        hudText.transform.position = hudPos;
        hudText.GetComponent<DamageText>().damage = damage;
    }
}
