using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class S_CollideAction : MonoBehaviour
{

    public UnityEvent<GameObject> OnTrigger;
    public UnityEvent<S_Player> OnTriggerPlayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnTrigger?.Invoke(collision.gameObject);
        var s = collision.gameObject.GetComponent<S_Player>();
        if(s != null) OnTriggerPlayer?.Invoke(s);
    }
}
