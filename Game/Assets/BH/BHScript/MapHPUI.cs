using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
public class MapHPUI : MonoBehaviour
{
    int HP;
    public GameObject HPText;
        private void Start() {
            LoadByHPJSON();
            HPText.GetComponent<Text>().text = HP.ToString();
        }

 private void LoadByHPJSON()
    {
       
        if(File.Exists(Application.dataPath + "/PlayerInfo.json"))
        {
            StreamReader sr = new StreamReader(Application.dataPath + "/PlayerInfo.json");
            string JsonString = sr.ReadToEnd();
            sr.Close();
            PlayerInformation.PlayerRun save =JsonUtility.FromJson<PlayerInformation.PlayerRun>(JsonString);
            Debug.Log("LOADED");

        ////
       HP = save.HP;

        
        }
        else
        {
            Debug.Log("NOT FOUND SAVE FILE");
        }
    }
}
