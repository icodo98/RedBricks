using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class broekenimage : MonoBehaviour
{
  
    
    public List<Sprite> BrokenpritesList;
    public int selectedOption;

    
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

  
  private void UpdateCharacter(int selectedOption)
   {
        gameObject.GetComponent<Image>().sprite = BrokenpritesList[selectedOption];
               //SelectCharacter character = characterDB.GetCharacter(selectedOption);
        //artworkSprite.sprite = character.characterSprite;
   }
   private void load()
    {
        Debug.Log("PlayerPrefs has key : " +PlayerPrefs.HasKey("selectedOption"));
        Debug.Log("PlayerPrefs selected option is : " +PlayerPrefs.GetInt("selectedOption"));
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }
}
