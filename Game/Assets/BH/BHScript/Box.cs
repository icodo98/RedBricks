using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Box : MonoBehaviour
{
    // Start is called before the first frame update
    public void BoxOpen()
    {
        GetComponent<LootBag>().InstantiateLoot(transform.position);
        Destroy(gameObject);
    }

    public void Gomap()
    {
        SceneManager.LoadScene(2);
    }
}
