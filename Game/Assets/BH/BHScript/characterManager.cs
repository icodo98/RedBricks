using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using UnityEditor;

public class characterManager : MonoBehaviour
{
    public CharacterDatabase characterDB;
  // public Text nameText;
    public SpriteRenderer artworkSprite;

    public int selectedOption;
   // public GameObject playerskin;

    public Animator transtiton;
    public float transtitonTime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
        if(!PlayerPrefs.HasKey("selectedOption"))
        {
            selectedOption = 0;
        }
        else
        {
            load();
        }
        UpdateCharacter(selectedOption);
        
    }

   public void NextOption()
   {
        selectedOption++;

        if(selectedOption >= characterDB.characterCount)
        {
            selectedOption = 0;
        }
        UpdateCharacter(selectedOption);
        Save();
        Debug.Log("Saved option : " + PlayerPrefs.GetInt("selectedOption"));
   }

   public void BackOption()
   {
    selectedOption--;
    
    if(selectedOption < 0)
    {
        selectedOption = characterDB.characterCount -1;
    }
        UpdateCharacter(selectedOption);
        Save();
        Debug.Log("Saved option : " + PlayerPrefs.GetInt("selectedOption"));
   }
   private void UpdateCharacter(int selectedOption)
   {
        SelectCharacter character = characterDB.GetCharacter(selectedOption);
        artworkSprite.sprite = character.characterSprite;
    //    nameText.text = character.characterName;
   }
   
   private void load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }
    
    private void Save() 
    {
        PlayerPrefs.SetInt("selectedOption", selectedOption);
       PlayerPrefs.Save();
    }
   /*
   public void ChangeSene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
    */
    public void PlayGameButton()
    {
        StartCoroutine(LoadLevel());
        //PrefabUtility.SaveAsPrefabAsset(playerskin, "Assets/BH/BHprefab/selectedskin.prefab");
       
    }


    IEnumerator LoadLevel()
    {
        transtiton.SetTrigger("Start");
        yield return new WaitForSeconds(transtitonTime);
        SceneManager.LoadScene(2);
    }
}
