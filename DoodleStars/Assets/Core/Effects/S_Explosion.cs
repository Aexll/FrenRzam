using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Explosion : MonoBehaviour
{
    public float radius;
    public bool isExploding = false;

    public void Explode()
    {
        var p = GameObject.FindGameObjectWithTag("Player");
        if (p != null)
        {
            if (Vector3.Distance(p.transform.position, transform.position) <= radius)
            {
                var s = p.GetComponent<S_Player>();
                s.IsAlive = false;
            }
        }
    }

    public void SetIsExploding(bool isIt)
    {
        isExploding = isIt;
    }

    private void Update()
    {
        if(isExploding)
        {
            Explode();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
