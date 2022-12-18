using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.TextCore.Text;

public class S_SpriteChanger : MonoBehaviour
{
    public UnityEvent<int> OnUpdate;

    public CharacterDatabase characterDB;
    public ScriptableObject dataBase;

    public TextMeshProUGUI nameText;
    public SpriteRenderer artworkSprite;

    public void UpdateCharacter(int selectedOption)
    {
        SpriteCharacter character = characterDB.GetCharacter(selectedOption);
        artworkSprite.sprite = character.characterSprite;
        nameText.text = character.characterName;

        OnUpdate?.Invoke(selectedOption);
    }
    
}
