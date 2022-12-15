using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

enum E_IntTest
{
    EQUAL,
    GREATER,
    LESS,
    GREATER_OR_EQUAL,
    LESS_OR_EQUAL,
}


[Serializable]
struct T_IntEvent
{
    public E_IntTest condition;
    public int index;
    public UnityEvent action;
}

public class S_Counter : MonoBehaviour
{
    [SerializeField] private int counter;
    [SerializeField] private List<T_IntEvent> events;

    public UnityEvent<int> OnCounterChanged;

    public void Plus()
    {
        counter++;
        OnCounterChanged.Invoke(counter);

        foreach (var item in events)
        {
            switch (item.condition)
            {
                case E_IntTest.EQUAL:
                    if (item.index == counter) item.action?.Invoke();
                    break;
                case E_IntTest.GREATER:
                    if (counter > item.index) item.action?.Invoke();
                    break;
                case E_IntTest.LESS:
                    if (counter < item.index) item.action?.Invoke();
                    break;
                case E_IntTest.GREATER_OR_EQUAL:
                    if (counter >= item.index) item.action?.Invoke();
                    break;
                case E_IntTest.LESS_OR_EQUAL:
                    if (counter <= item.index) item.action?.Invoke();
                    break;
                default:
                    break;
            }
        }
    }

}
