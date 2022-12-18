using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_GetPlayerprefSprite : MonoBehaviour
{
    [SerializeField] private string fieldName;
    public SpriteRenderer theSprite;
    public CharacterDatabase characterDB;

    private void Start()
    {
        theSprite.sprite = characterDB.GetCharacter(PlayerPrefs.GetInt(fieldName)).characterSprite;
        Debug.Log(PlayerPrefs.GetInt(fieldName));
        //Debug.Log("saved " + characterDB.GetCharacter(PlayerPrefs.GetInt(fieldName)) + " to " + fieldName);
    }
}
