using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bricksFlyer : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;

    private float timer = 1f;
    private float distance = 8f;

    // Start is called before the first frame update
    void Start()
    {
        for(int i =0; i < 3; i++)
        {
            SpawnFloatingBricks(Random.Range(0f, distance));
        }
    }

    // Update is called once per frame
    void Update()
    {   
        timer -= Time.deltaTime;
        if(timer <= 0f)
        {
        SpawnFloatingBricks(distance);
        timer = 1f;
        }
    }
    public void SpawnFloatingBricks(float distance)
    {
        float angle = Random.Range(0f, 360f);
        Vector3 spawnPos = new Vector3(Mathf.Sin(angle), Mathf.Cos(angle),1.5f) * distance;
        Vector3 direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f,1f), 0f);
        float floatingSpeed = Random.Range(1f, 4f);
        float rotateSpeed = Random.Range(-1f,1f);

        var bricks = Instantiate(prefab, spawnPos, Quaternion.identity).GetComponent<flyingBricks>();
        bricks.SetFloatingBricks(direction, floatingSpeed, rotateSpeed, Random.Range(0.5f,1f));
    }
    private void OnTriggerExit2D(Collider2D collision) 
    {
        var bricks = collision.GetComponent<flyingBricks>();
        if(bricks != null)
        {
            Destroy(bricks.gameObject);
        }
    }
}

