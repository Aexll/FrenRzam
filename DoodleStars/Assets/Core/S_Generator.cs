using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Generator : MonoBehaviour
{
    public List<GameObject> platforms;
    public List<int> platform_raritys;
    public List<GameObject> bonus;
    public float spawnSize;
    public float spawnHeight;
    private int currentHeigth;
    private float xPos;


    private void Awake()
    {
        xPos = transform.position.x;

        for (int i = 0; i < platform_raritys.Count; i++)
        {
            for (int j = 0; j < platform_raritys[i]; j++)
            {
                platforms.Add(platforms[i]);
            }
        }
    }



    private void Start()
    {
        currentHeigth = Mathf.RoundToInt(gameObject.transform.position.y);
    }

    private void Update()
    {
        if(transform.position.y > currentHeigth)
        {
            currentHeigth = Mathf.RoundToInt(gameObject.transform.position.y) + 1;
            var s = Instantiate(platforms[Random.Range(0,platforms.Count)], new Vector3(xPos + Random.Range(spawnSize,-spawnSize),transform.position.y + spawnHeight, 0), Quaternion.identity);
            if(Random.Range(0,10) == 0) Instantiate(bonus[Random.Range(0,bonus.Count)], new Vector3(xPos + Random.Range(spawnSize,-spawnSize),transform.position.y + spawnHeight + 0.5f, 0), Quaternion.identity);
            var spawnScript = s.GetComponent<ISpawn>();
            if(spawnScript != null)
            {
                spawnScript.Spawn(currentHeigth/50);
            }
        }
    }

    private void OnDrawGizmos()
    {
        // spawn line
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector3(xPos + spawnSize, transform.position.y + 5, 0), new Vector3(xPos - spawnSize, transform.position.y + 5, 0));
    }
}
