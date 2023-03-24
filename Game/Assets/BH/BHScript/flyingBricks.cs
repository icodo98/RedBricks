using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyingBricks : MonoBehaviour
{
    private Vector3 direction;
    private float floatingSpeed;
    private float rotateSpeed;

    public void SetFloatingBricks(Vector3 direction, float floatingSpeed, float rotateSpeed, float size) 
    {
        
        this.direction = direction;
        this.floatingSpeed = floatingSpeed;
        this.rotateSpeed = rotateSpeed;

        transform.localScale = new Vector3(size, size, size);
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * floatingSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, 0f, rotateSpeed));
    }
}