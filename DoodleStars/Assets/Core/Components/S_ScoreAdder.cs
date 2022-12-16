using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_ScoreAdder : MonoBehaviour
{
    [SerializeField] int amount;

    public void AddScoreToPlayer(S_Player player)
    {
        var score = player.GetComponent<S_Score>();
        score.Score += amount;
    }
}
