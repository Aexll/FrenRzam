using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class S_ColorForTime : MonoBehaviour
{
    public UnityEvent<Color> OnColor;
    public Gradient gradient;

    public void ColorByPercent(float percent)
    {
        OnColor?.Invoke(gradient.Evaluate(1-percent));
    }
}
