using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class S_FlipFlop : MonoBehaviour
{
    public bool state = false;
    public UnityEvent OnA;
    public UnityEvent OnB;
    public UnityEvent OnAny;

    public void Exec()
    {
        state = !state;
        if(state) OnA.Invoke();
        else OnB.Invoke();
        OnAny.Invoke();
        print("lol");
    }
}
