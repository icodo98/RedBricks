using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CharacterDatabase : ScriptableObject
{
  public SelectCharacter[] character;

  public int characterCount
  {
    get
    {
        return character.Length;
    }
  }
    public SelectCharacter GetCharacter(int index) {
        {
            return character[index];
        }
    }
}
