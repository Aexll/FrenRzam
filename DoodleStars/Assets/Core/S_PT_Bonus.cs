using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class S_PT_Bonus : MonoBehaviour
{
    public UnityEvent<S_Player> OnPlayerTouch;

    public void Touch(S_Player player)
    {
        OnPlayerTouch?.Invoke(player);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("trigger");
        var ps = collision.gameObject.GetComponent<S_Player>();
        if(ps != null) { Touch(ps); }
    }

}
