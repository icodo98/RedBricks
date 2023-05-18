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
        Vector3 offset = new Vector3(0, height * 2f,0);
        transform.position = transform.position + offset;
    }
}
