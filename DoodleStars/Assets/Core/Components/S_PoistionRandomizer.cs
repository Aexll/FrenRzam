using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class S_PoistionRandomizer : MonoBehaviour
{

    [SerializeField] private Vector3 center;
    [SerializeField] private Vector3 boxExtend;
    [SerializeField] private float screenSize;
    private float playerX;

    public UnityEvent<Vector3> OnGenerated;

    private void Start()
    {
        var p = GameObject.FindGameObjectWithTag("Player");
        playerX = p.transform.position.x;
    }

    public void Generate()
    {
        var rx = Mathf.Clamp(Random.Range(transform.position.x - boxExtend.x, transform.position.x + boxExtend.x), playerX-screenSize, playerX+screenSize);
        var ry = Random.Range(-boxExtend.y, boxExtend.y);
        Vector3 rpos = new Vector3(rx, transform.position.y + center.y + ry, 0);
        OnGenerated?.Invoke(rpos);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireCube(center, boxExtend);
    }
}

