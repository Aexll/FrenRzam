using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class S_Delayer : MonoBehaviour
{

    public bool loop = false;
    public UnityEvent<float> OnFusePercent;
    public UnityEvent OnTrigger;
    public float delay;

    private Coroutine currentCoroutine;


    public void StartDelayer()
    {
        currentCoroutine = StartCoroutine(DelayThenTrigger());
    }

    public void StopDelayer()
    {
        if(currentCoroutine != null) { StopCoroutine(currentCoroutine); }
        loop = false;
    }

    public IEnumerator DelayThenTrigger()
    {
        do
        {
            float time = delay;
            while (time > 0)
            {
                OnFusePercent.Invoke(time/delay);
                time-=Time.deltaTime;
                yield return null;
            }
            OnTrigger?.Invoke();
        } while (loop);
    }
}
