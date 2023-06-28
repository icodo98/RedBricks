using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapPlayer : MonoBehaviour
{

    //public GameObject selectedskin;
    //public GameObject player;
    //private Sprite playerSprite;
    
    public CharacterDatabase characterDB;

    public SpriteRenderer artworkSprite;

    public int selectedOption;

    characterManager CM = new characterManager();
    //ToDo 배틀씬에서는 mesh renderer와 material이고 map씬과 다른 씬에서는 sprite임. 

    // Start is called before the first frame update
    
    
    void Start()
    { 
        selectedOption = CM.selectedOption;
       // playerSprite = selectedskin.GetComponent<SpriteRenderer>().sprite;

       // player.GetComponent<SpriteRenderer>().sprite = playerSprite;
       

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

  
  private void UpdateCharacter(int selectedOption)
   {
        SelectCharacter character = characterDB.GetCharacter(selectedOption);
        artworkSprite.sprite = character.characterSprite;
   }
   private void load()
    {
        Debug.Log("PlayerPrefs has key : " +PlayerPrefs.HasKey("selectedOption"));
        Debug.Log("PlayerPrefs selected option is : " +PlayerPrefs.GetInt("selectedOption"));
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }
   
}
