using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CharacterDatabase : ScriptableObject
{
    public SpriteCharacter[] character;

    public int characterCount
    {
        get 
        {
            return character.Length;
        }
    }

    public SpriteCharacter GetCharacter(int index)
    {
        return character[index];
    }
}
