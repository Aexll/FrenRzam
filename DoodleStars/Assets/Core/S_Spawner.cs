using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Spawner : MonoBehaviour
{
    [SerializeField] GameObject toSpawn;
    [SerializeField] Transform spawnTransform;

    public void Act()
    {
        if (toSpawn != null)
        {
            if (spawnTransform != null)
                Instantiate(toSpawn, spawnTransform.transform.position, Quaternion.identity);
            else Instantiate(toSpawn, gameObject.transform.position , Quaternion.identity);
        }
    }
}
