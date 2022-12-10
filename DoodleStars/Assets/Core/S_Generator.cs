using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Generator : MonoBehaviour
{
    public List<GameObject> platforms;
    private int currentHeigth;
    private float xPos;

    private void Start()
    {
        currentHeigth = Mathf.RoundToInt(gameObject.transform.position.y);
        xPos = transform.position.x;
    }

    private void Update()
    {
        if(transform.position.y > currentHeigth)
        {
            currentHeigth = Mathf.RoundToInt(gameObject.transform.position.y) + 1;
            Instantiate(platforms[0], new Vector3(xPos + Random.Range(5,-5),transform.position.y + 5, 0), Quaternion.identity);
        }
    }
}
