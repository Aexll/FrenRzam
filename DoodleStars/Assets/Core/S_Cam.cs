using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Cam : MonoBehaviour
{
    [SerializeField] private GameObject toFocus;
    private float lastY = 0;

    private void Update()
    {
        if(toFocus.transform.position.y > lastY)
        {
            lastY = toFocus.transform.position.y;
            gameObject.transform.position = new Vector3(transform.position.x, lastY, transform.position.z);
        }
    }
}
