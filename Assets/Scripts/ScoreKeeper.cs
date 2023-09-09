using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    private int score = 0;

    static ScoreKeeper instance;

    private void Awake()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public int GetScore()
    {
        return this.score;
    }

    public void IncreaseScore(int value)
    {
        this.score += value;
        Mathf.Clamp(this.score, 0, int.MaxValue);
        Debug.Log(score);
    }

    public void ResetScore()
    {
        this.score = 0;
    }
}
