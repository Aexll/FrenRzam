using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Moving : MonoBehaviour
{
    [SerializeField] private Vector3 toGo;
    [SerializeField] private float speed;
    private Vector3 fromGo;
    private float percent;
    private bool isMovingFore;

    private void Start()
    {
        fromGo = transform.position;
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(fromGo, fromGo + toGo, percent);
        if(isMovingFore)
        {
            percent += Time.deltaTime * speed;
            if(percent >= 1) isMovingFore = false;
        }
        else
        {
            percent -= Time.deltaTime * speed;
            if(percent <= 0) isMovingFore = true;
        }
    }
}
