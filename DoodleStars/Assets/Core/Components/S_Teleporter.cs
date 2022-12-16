using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Teleporter : MonoBehaviour
{

    [SerializeField] private Transform fromTransform;
    [SerializeField] private Transform toTransform;

    public void TeleportPlayer(S_Player player)
    {
        Teleport(player.gameObject);
    }

    public void Teleport(GameObject go)
    {
        Vector3 delta = toTransform.position - fromTransform.position;
        go.transform.Translate(delta);
    }
}
