using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Boost : MonoBehaviour
{

    [SerializeField] float duration = 1;
    [SerializeField] float force = 1;
    [SerializeField] string wearable = "hat";

    public void BoostPlayer(S_Player p)
    {
        p.s_perks.SetWearableByName(wearable,true);
        p.Boost(duration,force,wearable);
    }
}
