using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class S_Jump : MonoBehaviour
{
    public UnityEvent OnJump;
    [SerializeField] float jumpforce = 1;

    public void Jump(S_Player player)
    {
        player.Jump(jumpforce);
    }
}
