using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class S_Input : MonoBehaviour
{

    public float xAxis = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            xAxis = -1;

        } else if (Input.GetKey(KeyCode.D))
        {
            xAxis = 1;

        } else
        {
            xAxis = 0;
        }
    }
}
