using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_GetPlayerprefSprite : MonoBehaviour
{
    public Sprite theSprite;
    public CharacterDatabase characterDB;

    private void Start()
    {
        theSprite = characterDB.GetCharacter(PlayerPrefs.GetInt("selectedCharacter")).characterSprite;
    }
}
