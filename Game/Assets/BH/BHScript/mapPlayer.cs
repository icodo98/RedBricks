using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapPlayer : MonoBehaviour
{
    public CharacterDatabase characterDB;
    public SpriteRenderer artworkSprite;

    private int selectedOption = 0;

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

  private void UpdateCharacter(int selectedOption)
   {
        SelectCharacter character = characterDB.GetCaharacter(selectedOption);
        artworkSprite.sprite = character.characterSprite;
   }
   private void load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }
   
}
