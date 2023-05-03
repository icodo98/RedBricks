using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DamageText : MonoBehaviour
{
    public float fontspeed; //txt 이동속도
    public float transparentspeed; //투명도 속도
    public float destroyTime;
    TextMeshPro text; 
    Color damagecolor;
    public int damage;
   
    void Start()
    {
        text = GetComponent<TextMeshPro>();
        text.text = damage.ToString();
        damagecolor = text.color;
        Invoke("DestroyObject", destroyTime);
    }

   // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, fontspeed * Time.deltaTime, 0));
        damagecolor.a = Mathf.Lerp(damagecolor.a, 0, Time.deltaTime* transparentspeed);
        text.color = damagecolor;
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}
