using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class S_SpriteCustomizer : MonoBehaviour
{

    [SerializeField] private List<Sprite> default_sprite;
    [SerializeField] private List<string> default_names;

    public Dictionary<string, Sprite> spritesList = new Dictionary<string, Sprite>();

    public UnityEvent<Sprite> OnSpriteChanged;

    public void SetSprite(string spriteName)
    {
        if(spriteName != null)
        {
            PlayerPrefs.SetString("playerSprite", spriteName);
            OnSpriteChanged?.Invoke(spritesList[spriteName]);
        }
    }

    private void Awake()
    {
        for (int i = 0; i < Mathf.Min(default_names.Count,default_sprite.Count); i++)
        {
            spritesList[default_names[i]] = default_sprite[i];
        }
    }

    private void Start()
    {
        // load the sprite saved
        SetSprite(PlayerPrefs.GetString("playerSprite"));
    }

}
