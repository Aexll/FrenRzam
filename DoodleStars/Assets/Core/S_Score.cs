using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class S_Score : MonoBehaviour
{

    public UnityEvent OnScoreChanged;
    public UnityEvent<string> OnScoreChangedText;

    [SerializeField] private int defaultScore;
    private int score;
    public int Score
    {
        get { return score; }
        set { 
            score = value;
            OnScoreChanged?.Invoke();
            OnScoreChangedText?.Invoke(score.ToString());
        }
    }

    private void Awake()
    {
        Score = defaultScore;
    }

    public void Collected(S_Score by)
    {
        by.Score+=Score;
        Score = 0;
    }

    public void CollectedByPlayer(S_Player player)
    {
        var a = player.GetComponent<S_Score>();
        if (a != null)
        {
            Collected(a);
        }
    }
}
