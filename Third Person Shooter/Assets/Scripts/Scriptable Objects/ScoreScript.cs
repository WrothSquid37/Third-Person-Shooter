using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    [HideInInspector] public float score;

    void Start()
    {
        score = 0;
    }

    public void AddScore(float amount)
    {
        score += amount;
    }

    public void RemoveScore(float amount)
    {
        score -= amount;
    }

    public float GetScore()
    {
        return score;
    }

}
