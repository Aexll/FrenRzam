using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class S_PT_Platform : MonoBehaviour
{
    public UnityEvent<S_Player> OnPlayerTouch;

    public void Touch(S_Player player)
    {
        OnPlayerTouch?.Invoke(player);
    }
}
