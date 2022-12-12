using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class S_DirectionSorter : MonoBehaviour
{
    public Direction acceptDirection = Direction.ALL;
    public UnityEvent<S_Player> OnAccept;
    public UnityEvent<S_Player> OnDecline;

    public void Accept(bool accept, S_Player player)
    {
        if(accept)
        {
            OnAccept?.Invoke(player);
        }
        else
        {
            OnDecline?.Invoke(player);
        }
    }

    public void SortPlayer(S_Player player)
    {
        switch (acceptDirection)
        {
            case Direction.ALL:
            case Direction.VERTICAL:
                Accept(true, player);
                break;
            case Direction.UP:
                Accept(player.isMovingUp, player);
                break;
            case Direction.DOWN:
                Accept(!player.isMovingUp, player);
                break;

            default:
                Accept(false, player);
                break;
        }
    }
}
