using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface ISpawn
{
    public void Spawn(int difficulty);
}

public class S_Moving : MonoBehaviour, ISpawn
{
    [SerializeField] private bool horizontal = true;
    [SerializeField] private bool speedByHeight = true;
    [SerializeField] private Vector3 toGo;
    [SerializeField] private float speed = 0.2f;
    [SerializeField] private bool relative = true;
    [SerializeField] private bool autoStart = true;
    [SerializeField] private bool loop = true;
    private Vector3 fromGo;
    private float percent;
    private bool isMovingFore;
    private bool isMoving = false;

    public UnityEvent<Vector3> OnDestinationReached;


    public void Spawn(int diff)
    {
        if(speedByHeight)
            speed = Mathf.Clamp(0.2f * diff, 0.1f, 5);
        if (horizontal)
            toGo = new Vector3(Random.Range(-1, 1) > 0 ? Random.Range(-5, -1) : Random.Range(1, 5), 0, 0);
        else
            toGo = new Vector3(0, Random.Range(-1, 1) > 0 ? Random.Range(-5, -1) : Random.Range(1, 5), 0);

    }

    public void SetToGo(Vector3 go)
    {
        toGo = go;
    }

    public void StartMoving()
    {
        isMoving = true;
        fromGo = transform.position;
    }
    public void StopMoving()
    {
        isMoving = false;
    }

    private void Start()
    {
        if (autoStart)
        {
            StartMoving();
        }
    }

    private void Update()
    {
        if (isMoving)
        {
            Vector3 FinalToGo = relative ? fromGo + toGo : toGo;
            transform.position = Vector3.Lerp(fromGo, FinalToGo, percent);
            if (isMovingFore)
            {
                percent += Time.deltaTime * speed;
                if (percent >= 1)
                {
                    if (loop)
                        isMovingFore = false;
                    else
                    {
                        isMoving = false;
                        percent = 0;
                        OnDestinationReached?.Invoke(FinalToGo);
                    }
                }
            }
            else
            {
                percent -= Time.deltaTime * speed;
                if (percent <= 0) isMovingFore = true;
            }

        }
    }
}
