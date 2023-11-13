using UnityEngine;

public class Enemytext : MonoBehaviour
{
    public GameObject hudDamageText;
    public int HP = 5;
    public int Amor;
    
    public bool TakeDamage(float damage,Vector3 hudPos)
    {
        int normalizedDamage;

        // Apply Amor. 현재는 block별 아머가 따로 없으므로 1로 고정. 추후 레벨별 혹은 블럭별로 설정필요.
        damage -= Amor;

        // 소수점 버림.
        normalizedDamage = Mathf.FloorToInt(damage);
        if( normalizedDamage < 0) normalizedDamage = 0;
        HP -= normalizedDamage;

        DisplayDamage(normalizedDamage, hudPos);
        if(HP < 0) { 
            Destroy(this.gameObject);
            return true;
        }
        return false;
    }
    public bool TakeDamage(float damage)
    {
        int normalizedDamage;
        Vector3 hudPos = transform.position;

        // Apply Amor. 현재는 block별 아머가 따로 없으므로 1로 고정. 추후 레벨별 혹은 블럭별로 설정필요.
        damage -= Amor;

        // 소수점 버림.
        normalizedDamage = Mathf.FloorToInt(damage);
        if (normalizedDamage < 0) normalizedDamage = 0;
        HP -= normalizedDamage;

        DisplayDamage(normalizedDamage, hudPos);
        if (HP < 0)
        {
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
