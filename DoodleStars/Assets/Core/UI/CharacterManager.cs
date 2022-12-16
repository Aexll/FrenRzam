using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Events;

public class CharacterManager : MonoBehaviour
{
    /*
    public UnityEvent onButtonPressed;
    public CharacterDatabase characterDB;
    public ScriptableObject dataBase;

    public TextMeshProUGUI nameText;
    public SpriteRenderer artworkSprite;

    public string fieldPlayerPref;

    private int selectedOption = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey(fieldPlayerPref))
        {
            selectedOption = 0;
        }
        else
        {
            Load();
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

        onButtonPressed.Invoke();
        UpdateCharacter(selectedOption);
        Save();
    }

    public void PreviousOption()
    {
        selectedOption--;

        if(selectedOption < 0)
        {
            selectedOption = characterDB.characterCount - 1;
        }

        onButtonPressed.Invoke();
        UpdateCharacter(selectedOption);
        Save();
    }

    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt(fieldPlayerPref);
    }

    private void Save()
    {
        PlayerPrefs.SetInt(fieldPlayerPref, selectedOption);
    }
    */
}
