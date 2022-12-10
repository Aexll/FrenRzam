using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class S_PassUnder : MonoBehaviour
{
    public Transform Camera;
    public float deep = 4;

    public UnityEvent OnGoesUnder;

    private void Awake()
    {
        if(Camera == null) {
            Camera = GameObject.FindGameObjectWithTag("MainCamera").transform;
        }
    }

    void Update()
    {
        if(Camera.position.y > transform.position.y + deep)
        {
            OnGoesUnder.Invoke();
        }
    }
}
