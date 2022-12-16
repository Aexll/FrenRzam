using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class S_CastPlayer : MonoBehaviour
{
    private S_Player toCast;
    public UnityEvent<S_Player> OnAction;

    public void SetCast(S_Player cast)
    {
        toCast = cast;
    }

    public void Act()
    {
        OnAction?.Invoke(toCast);
    }
}
