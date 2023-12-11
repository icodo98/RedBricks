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

 

    // Start is called before the first frame update
    
    
    void Start()
    { 
        
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
       characterManager CM = gameObject.AddComponent<characterManager>();
        CM.characterDB = characterDB;
        CM.artworkSprite = gameObject.GetComponent<SpriteRenderer>();
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
