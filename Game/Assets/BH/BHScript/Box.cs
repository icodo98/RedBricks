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

    /////Load Secne///
    public void ToMap()
   {
        StartCoroutine(LoadLevel(2));
   }
    public void SavePlayerInfo()
    {
        string path = Application.dataPath + "/PlayerInfo.json";
        PlayerInformation.PlayerDataUtils.SaveDataAsJson(path, PlayerInformation.PlayerInfo.playerInfo);
    }

    public Animator transtiton;
    public float transtitonTime = 1f;
    
    
    IEnumerator LoadLevel(int scene)
    {
        transtiton.SetTrigger("Start");
        yield return new WaitForSeconds(transtitonTime);
        SceneManager.LoadScene(scene);
    }
}
