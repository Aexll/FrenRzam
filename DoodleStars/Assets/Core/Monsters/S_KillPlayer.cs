using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.Events;

public class S_KillPlayer : MonoBehaviour
{
    [SerializeField] private UnityEvent OnTouch;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.name == "Feet")
        {
            OnTouch?.Invoke();
        }
    }
}
