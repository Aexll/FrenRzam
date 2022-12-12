using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class S_Stunner : MonoBehaviour
{

    public void Stun(GameObject player)
    {
        var player_script = player.GetComponent<S_Player>();
        if (player_script != null)
        {
            Stun(player_script);
        }
    }

    public void Stun(S_Player player)
    {
        player.IsAlive = false;
    }
}
