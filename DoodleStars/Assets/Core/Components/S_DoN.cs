using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class S_DoN : MonoBehaviour
{
    [SerializeField] private int n;

    public UnityEvent<int> OnActionInt;
    public UnityEvent<S_Player> OnActionPlayer;

    public void Act(S_Player player)
    {
        for (int i = 0; i < n; i++)
        {
            OnActionInt?.Invoke(i);
            OnActionPlayer?.Invoke(player);
        }
    }
}
