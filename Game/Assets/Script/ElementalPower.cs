using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementalPower : MonoBehaviour
{
    int i = 0;
    bool isCoroutineRunnig = false;
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
                // ������ �ؽ�Ʈ�� ���� �Ͱ� ��ġ�Ƿ� ��ġ�� �� �ٸ��� ����
                damageTxt.TakeDamage(1, dmgPos);
            }
            else break;
            yield return waitFor1Second;
        }
        isCoroutineRunnig = false;
    }
}

