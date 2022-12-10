using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Boost : MonoBehaviour
{

    [SerializeField] float duration = 1;
    [SerializeField] float force = 1;

    public void BoostPlayer(S_Player p)
    {
        StartCoroutine(CoroutineBoostPlayer(p));
    }

    IEnumerator CoroutineBoostPlayer(S_Player toBoost)
    {
        toBoost.s_perks.has_hat = true;
        float time = 0;
        while (time < duration)
        {
            toBoost.Jump(force);
            time += Time.deltaTime;
            yield return null;
        }
        toBoost.s_perks.has_hat = false;

    }
}
