using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Debris : MonoBehaviour
{
    [SerializeField] private Rigidbody2D m_rigidbody2D;
    [SerializeField] private Transform impactPosition;
    public float torque = 5;
    public float force = 100;

    private void Start()
    {
        m_rigidbody2D.AddTorque(torque);
        m_rigidbody2D.AddForce((transform.position - impactPosition.position)*force);
    }

    public void AddForce(Vector2 force)
    {
        m_rigidbody2D.AddForce(force);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        var d = m_rigidbody2D.transform.position - impactPosition.position;
        Gizmos.DrawLine(m_rigidbody2D.transform.position, m_rigidbody2D.transform.position + d);
    }
}
