using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class S_AnimSize : MonoBehaviour
{
    /* list of transform to animates */
    [SerializeField] private List<Transform> toAnimate;

    public AnimationCurve sizeX = new AnimationCurve(new Keyframe[]{new Keyframe(0,0),new Keyframe(1,1)});
    public AnimationCurve sizeY = new AnimationCurve(new Keyframe[]{new Keyframe(0,0),new Keyframe(1,1)});
    
    /* speed of the animation, 1 = 1 seconde */
    [SerializeField] private float speed;

    /* dont stop already running coroutine */
    [SerializeField] private bool restartIfRunning;

    /* default size fo the transform */
    private List<Vector3> defaultSizes = new List<Vector3>();


    Coroutine currentCoroutine;

    /* events */
    public UnityEvent<float> OnAnimation;
    public UnityEvent OnEndAnimation;

    public void Animate()
    {
        /* if the coroutine is already running */
        if (currentCoroutine != null && restartIfRunning) return;

        if(currentCoroutine != null)
            StopCoroutine(currentCoroutine);

        /* set the default transform */
        defaultSizes.Clear();
        foreach (var item in toAnimate)
        {
            defaultSizes.Add(item.localScale);
        }

        currentCoroutine = StartCoroutine(C_Animation(1));
    }

    public IEnumerator C_Animation(float maxTime)
    {
        float time = 0;
        while (time < maxTime)
        {
            for (int i = 0; i < toAnimate.Count; i++)
            {
                toAnimate[i].localScale = new Vector3(defaultSizes[i].x * sizeX.Evaluate(time/maxTime), defaultSizes[i].y * sizeY.Evaluate(time/maxTime), 1);
            }
            time += Time.deltaTime * speed;
            yield return null;
        }
        OnEndAnimation?.Invoke();
    }
}
