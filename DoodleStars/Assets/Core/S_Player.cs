using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(S_Perks))]
public class S_Player : MonoBehaviour
{
    [SerializeField] public S_Perks s_perks;
    [SerializeField] S_Input s_input;
    [SerializeField] Transform m_feets;
    [SerializeField] float screenSize = 5;
    [SerializeField] float spawnSize = 5;
    [SerializeField] float feetSize;
    [SerializeField] float gravityScale = 5;
    [SerializeField] float jumpForce = 5;
    [SerializeField] float horizontalVelocity = 5;
    public float upwardVelocity;
    private float defaultX;

    /* events */
    public UnityEvent OnDeath;
    public UnityEvent<Vector3> OnJump;



    private bool isAlive = true;
    public bool IsAlive
    {
        get { return isAlive; }
        set
        {
            if (isAlive != value && !(boostTime>0))
            {
                isAlive = value;
                if (!value) // on death
                {
                    upwardVelocity = jumpForce * 0.5f; // little jump
                    OnDeath?.Invoke();
                }
            }
        }
    }

    /* boost */
    private float boostTime = 0;
    private float boostForce = 1;
    private float boostAcceleration = 1;
    private string boostName = "hat";

    public Vector2 feet2DPos
    {
        get { return m_feets.position; }
    }

    public bool isMovingUp
    {
        get { return upwardVelocity > 0; }
    }

    private void Awake()
    {
        defaultX = transform.position.x;
    }

    private void Update()
    {


        // gravity affect vertical velocity
        upwardVelocity -= Time.deltaTime * gravityScale;

        if (IsAlive)
        {
            // if bouncing on a platform
            if (!isMovingUp && TouchPlatform())
            {
                // do somthing every time it touch a platform
                OnJump?.Invoke(gameObject.transform.position);
            }

            // boost
            if (boostTime > 0)
            {
                boostTime -= Time.deltaTime;
                upwardVelocity = Mathf.Clamp(upwardVelocity + 0.01f * boostAcceleration, 0, boostForce);
                if (boostTime <= 0)
                {
                    // when the boost ends
                    s_perks.SetWearableByName(boostName, false);
                }
            }

            // teleportation
            if (transform.position.x < -screenSize + defaultX) transform.position += new Vector3(2 * screenSize, 0, 0);
            if (transform.position.x > screenSize + defaultX) transform.position -= new Vector3(2 * screenSize, 0, 0);

            // moving the object horizontaly
            if(s_input)
                transform.transform.Translate(Vector3.right * Time.deltaTime * 8 * s_input.xAxis * horizontalVelocity);

        }

        // move verticaly
        transform.transform.Translate(Vector3.up * upwardVelocity * Time.deltaTime * 8);
    }


    public void Jump()
    {
        upwardVelocity = jumpForce;
    }

    public void Jump(float force)
    {
        upwardVelocity = jumpForce * force;
    }

    public void Boost(float time, float force, string hatName)
    {
        // remove old hat
        if (boostTime > 0) { s_perks.SetWearableByName(boostName, false); }
        boostTime = Mathf.Max(boostTime, time);
        boostForce = force;
        boostName = hatName;
    }



    // is touching a platform
    public bool TouchPlatform()
    {
        RaycastHit2D ray1;
        RaycastHit2D ray2;

        ray1 = feetRay(0);
        ray2 = feetRay(1);

        // bound only once per platform
        List<S_PT_Platform> touchedList = new List<S_PT_Platform>();
        S_PT_Platform colEftScript;
        foreach (var item in new List<RaycastHit2D>() { ray1, ray2 })
        {
            if (!item) continue;
            colEftScript = item.transform.gameObject.GetComponent<S_PT_Platform>();
            if (colEftScript != null && !touchedList.Contains(colEftScript))
            {
                colEftScript.Touch(this);
                touchedList.Add(colEftScript);
            }
        }

        return ray1 || ray2;
    }

    // trace ray from in the feet range
    public RaycastHit2D feetRay(float percent, float length = 0.05f, bool debug = false)
    {
        float offset = Mathf.Lerp(-feetSize * 0.5f, feetSize * 0.5f, percent);
        if (debug) Debug.DrawRay(m_feets.transform.position + (Vector3.right * offset), Vector3.down * length, Color.green, 0.1f);
        return Physics2D.Raycast(new Vector2(m_feets.transform.position.x + offset, m_feets.transform.position.y), Vector2.down, length);

    }

    // draw debug
    private void OnDrawGizmos()
    {
        const float scaleUp = 0.1f;
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(m_feets.position + Vector3.up * scaleUp * 0.5f, new Vector3(feetSize, scaleUp, 0.1f));

        // teleport lines
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(new Vector3(screenSize + defaultX, transform.position.y + screenSize, 0), new Vector3(screenSize + defaultX, transform.position.y - screenSize, 0));
        Gizmos.DrawLine(new Vector3(-screenSize + defaultX, transform.position.y + screenSize, 0), new Vector3(-screenSize + defaultX, transform.position.y - screenSize, 0));

        // spawn line
        // Gizmos.color = Color.red;
        // Gizmos.DrawLine(new Vector3(defaultX + spawnSize, transform.position.y + 5, 0), new Vector3(defaultX - spawnSize, transform.position.y + 5, 0));
    }
}
