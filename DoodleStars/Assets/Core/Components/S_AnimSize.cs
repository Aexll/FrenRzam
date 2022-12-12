using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class S_AnimSize : MonoBehaviour
{
    [SerializeField] private Transform toAnimate;
    public AnimationCurve sizeX = new AnimationCurve(new Keyframe[]{new Keyframe(0,0),new Keyframe(1,1)});
    public AnimationCurve sizeY;
    [SerializeField] private float speed;

    Coroutine currentCoroutine;

    public UnityEvent OnEndAnimation;

    public void Animate()
    {
        if (currentCoroutine != null) StopCoroutine(currentCoroutine);
        currentCoroutine = StartCoroutine(C_Animation(1));
    }

    public IEnumerator C_Animation(float time)
    {
        while (time > 0)
        {
            toAnimate.localScale = new Vector3(sizeX.Evaluate(time),sizeY.Evaluate(time), 1);
            time -= Time.deltaTime * speed;
            yield return null;
        }
        OnEndAnimation?.Invoke();
    }
}
