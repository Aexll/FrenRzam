using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class S_Input : MonoBehaviour
{

    public float xAxis = 0;

    [SerializeField] private GameObject spriteLeft;
    [SerializeField] private GameObject spriteRight;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            xAxis = -1;
            spriteLeft.SetActive(true);
            spriteRight.SetActive(false);

        } else if (Input.GetKey(KeyCode.D))
        {
            xAxis = 1;
            spriteLeft.SetActive(false);
            spriteRight.SetActive(true);

        } else
        {
            xAxis = 0;
        }
    }
}
