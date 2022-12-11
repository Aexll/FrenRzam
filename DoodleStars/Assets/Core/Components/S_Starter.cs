using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class S_Starter : MonoBehaviour
{
    public UnityEvent OnStart;

    // Start is called before the first frame update
    void Start()
    {
        OnStart?.Invoke();
    }
}
