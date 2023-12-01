using TMPro;
using UnityEngine;

public class Enemytext : MonoBehaviour
{
    public GameObject hudDamageText;
    public int HP = 5;
    public int Amor;

    public bool TakeDamage(float damage, Vector3 hudPos)
    {
        Color color = Color.red;
        return TakeDamage(damage, hudPos, color);
    }
    public bool TakeDamage(float damage)
    {
        Vector3 hudPos = transform.position;
        return TakeDamage(damage, hudPos);   
    }
    public bool TakeDamage(float damage, Vector3 hudPos, Color color)
    {
        int normalizedDamage;

        // Apply Amor. ����� block�� �ƸӰ� ���� �����Ƿ� 1�� ����. ���� ������ Ȥ�� ������ �����ʿ�.
        damage -= Amor;

        // �Ҽ��� ����.
        normalizedDamage = Mathf.FloorToInt(damage);
        if (normalizedDamage < 0) normalizedDamage = 0;
        HP -= normalizedDamage;

        DisplayDamage(normalizedDamage, hudPos, color);
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
        hudText.GetComponent<DamageText>().damage = damage;;
    }
    private void DisplayDamage(int damage, Vector3 hudPos, Color color)
    {
        GameObject hudText = Instantiate(hudDamageText);
        hudText.transform.position = hudPos;
        hudText.GetComponent<DamageText>().damage = damage;
        hudText.GetComponent<TextMeshPro>().color = color;
    }
}
