using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class S_Break : MonoBehaviour
{
    public UnityEvent OnBreak;

    public void Break()
    {
        Destroy(gameObject);
        OnBreak?.Invoke();
    }
}
