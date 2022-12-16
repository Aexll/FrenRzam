using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class S_Random : MonoBehaviour
{
    [SerializeField] private bool autoStart;

    public UnityEvent<int> OnGeneratedInt;
    public UnityEvent<float> OnGeneratedFloat;
    public UnityEvent<bool> OnGeneratedBool;

    public List<UnityEvent> eventlist;

    private void Start()
    {
        if (autoStart)
        {
            TriggerRandomEvent();
        }
    }

    public void GenInt(int min, int max)
    {
        OnGeneratedInt?.Invoke(Random.Range(min, max));
    }
    public void GenFloat(float min, float max)
    {
        OnGeneratedFloat?.Invoke(Random.Range(min, max));
    }

    public void TriggerRandomEvent()
    {
        if (eventlist != null && eventlist.Count > 0)
        {
            eventlist[Random.Range(0,eventlist.Count)]?.Invoke();
        }
    }

}
