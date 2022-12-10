using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Perks : MonoBehaviour
{
    public GameObject hat;

    public bool has_hat
    {
        get { return hat.active; }
        set { hat.SetActive(value); }
    }
}
