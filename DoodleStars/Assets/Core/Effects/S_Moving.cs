using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISpawn
{
    public void Spawn(int difficulty);
}

public class S_Moving : MonoBehaviour, ISpawn
{
    [SerializeField] private Vector3 toGo;
    [SerializeField] private float speed;
    private Vector3 fromGo;
    private float percent;
    private bool isMovingFore;


    public void Spawn(int diff)
    {
        speed = Mathf.Clamp(0.2f * diff, 0.1f, 5);
        toGo = new Vector3(Random.Range(-1, 1) > 0 ? Random.Range(-5, -1) : Random.Range(1, 5), 0, 0);
    }


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
