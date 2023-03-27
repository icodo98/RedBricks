using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class characterManager : MonoBehaviour
{
    public CharacterDatabase characterDB;
    public SpriteRenderer artworkSprite;

    private int selectedOption = 0;
    public GameObject playerskin;
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
   }
   private void UpdateCharacter(int selectedOption)
   {
        SelectCharacter character = characterDB.GetCaharacter(selectedOption);
        artworkSprite.sprite = character.characterSprite;
   }
   private void load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }
    private void Save() 
    {
        PlayerPrefs.SetInt("SelectedOption", selectedOption);
    }
   /*
   public void ChangeSene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
    */
    public void PlayGameButton(int sceneID)
    {
        PrefabUtility.SaveAsPrefabAsset(playerskin, "Assets/selectedskin.prefab");
        SceneManager.LoadScene(sceneID);
    }
}
