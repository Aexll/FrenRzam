using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Spawner : MonoBehaviour
{
    [SerializeField] S_Player playerRef;
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
    public void ActVelocity(Vector3 vel)
    {
        if (toSpawn != null)
        {
            GameObject obj;
            if (spawnTransform != null)
                obj = Instantiate(toSpawn, spawnTransform.transform.position, Quaternion.identity);
            else
                obj = Instantiate(toSpawn, gameObject.transform.position , Quaternion.identity);
            var rb = obj.GetComponent<Rigidbody2D>();
            if(rb != null) rb.velocity = vel;
        }
    }
    public void ActPlayerVelocity()
    {
        if (toSpawn != null)
        {
            GameObject obj;
            if (spawnTransform != null)
                obj = Instantiate(toSpawn, spawnTransform.transform.position, Quaternion.identity);
            else
                obj = Instantiate(toSpawn, gameObject.transform.position , Quaternion.identity);

            Vector2 heritedForce = Vector2.up * playerRef.upwardVelocity;

            var rb = obj.GetComponent<Rigidbody2D>();
            if (rb != null) rb.AddForce(heritedForce); // .velocity =  rb.velocity + Vector2.up * playerRef.upwardVelocity * 100;

            var sd = obj.GetComponent<S_Debris>();
            if (sd != null) sd.AddForce(heritedForce * 250);


        }
    }


    public void SetToSpawn(GameObject _toSpawn)
    {
        if (_toSpawn == null) return;
        toSpawn = _toSpawn;
    }

    public void SetToSpawnTransfrom(Transform _toSpawnTransfrom)
    {
        spawnTransform = _toSpawnTransfrom;
    }


}
