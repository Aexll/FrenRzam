using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class S_Monster : MonoBehaviour
{
    [SerializeField] private Sprite[] spriteImages;
    [SerializeField] private SpriteRenderer toChange;

    private void Start()
    {
        toChange.sprite = spriteImages[Random.Range(0, spriteImages.Length-1)];
    }
}
