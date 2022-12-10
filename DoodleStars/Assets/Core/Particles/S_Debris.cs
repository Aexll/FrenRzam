using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Debris : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody2D;
    [SerializeField] private Transform impactPosition;
    public float torque = 5;
    public float force = 100;

    private void Start()
    {
        //rigidbody2D.AddForceAtPosition(Vector2.up * force,impactPosition.position);
        rigidbody2D.AddTorque(torque);
        rigidbody2D.AddForce((transform.position - impactPosition.position)*force);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        var d = transform.position - impactPosition.position;
        Gizmos.DrawLine(transform.position, transform.position + d);
    }
}
