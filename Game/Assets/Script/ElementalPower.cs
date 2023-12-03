using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementalPower : MonoBehaviour
{
    int i = 0;
    bool isCoroutineRunnig = false;
    public Vector2 ElectricSize = new Vector2(0.6f,0.2f);
    public void FirePower(Collision2D other) {
        if (isCoroutineRunnig)
        {
            i = 0;
        }
        else
        {
            StartCoroutine(FIrePower(other));
        }

    }

    IEnumerator FIrePower(Collision2D other)
    {
        isCoroutineRunnig = true;
        Enemytext damageTxt =  other.gameObject.GetComponent<Enemytext>();
        Vector3 dmgPos = other.transform.position + new Vector3(0.05f,-0.1f,0);
        WaitForSecondsRealtime waitFor1Second = new WaitForSecondsRealtime(1);
        for (i = 0; i < 6; i++)
        {
            Debug.Log(this.GetInstanceID()+" "+i);
            if (damageTxt != null)
            {
                // 데미지 텍스트가 기존 것과 겹치므로 위치를 좀 다르게 수정
                damageTxt.TakeDamage(1, dmgPos);
            }
            else break;
            yield return waitFor1Second;
        }
        isCoroutineRunnig = false;
    }

    /// <summary>
    /// Electric elemental ability.damage multiple nearby objects.
    /// </summary>
    /// <param name="other"></param>
    public void ElectricPower(Collision2D other)
    {
        // Find blcoks in range
        Collider2D[] rangeBoxes = Physics2D.OverlapBoxAll(other.transform.position, ElectricSize,0);

        foreach (Collider2D rangeBox in rangeBoxes)
        {
            if (rangeBox == null) continue;
            if (!rangeBox.CompareTag("Block") || rangeBox.transform == transform) continue; // Exception handle. exclude ball and itself.
            rangeBox.gameObject.GetComponent<Enemytext>().TakeDamage(1, rangeBox.transform.position + new Vector3(0.05f, -0.1f, 0), Color.blue);

        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, ElectricSize);
    }

    public void WaterPower(Collision2D other)
    {

    }
}

