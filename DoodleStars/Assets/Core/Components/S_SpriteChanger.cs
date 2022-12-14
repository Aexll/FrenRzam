using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class S_SpriteChanger : MonoBehaviour
{

    [SerializeField] private List<SpriteRenderer> spriteToChange;

    public UnityEvent OnSpriteChanged;

    public void ChangeTo(Sprite sprite)
    {
        if(spriteToChange.Count> 0)
        {
            if (spriteToChange[0].sprite != sprite)
            {
                foreach (var item in spriteToChange)
                {
                    item.sprite = sprite;
                }
                OnSpriteChanged?.Invoke();
            }

        }
    }
}
