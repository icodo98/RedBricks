using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public float speed;
    private float height = 6.4f;

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if (transform.position.y <= -height)
        {
            Reposition();
        }

    }

    void Reposition()
    {
        Vector2 offset = new Vector2(0, height * 2f);
        transform.position = (Vector2)transform.position + offset;
    }



}
