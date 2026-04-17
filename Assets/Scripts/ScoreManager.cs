using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [Header("Score Settings")]
    [SerializeField] private int addScore = 1;

    static ScoreManager instance;
    private int score = 0;
    public void ResetScore() => score = 0;

    void Awake()
    {
        InitSingleton();
    }

    void InitSingleton()
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
        return score;
    }

    public void AddToScore()
    {
        score += addScore;
    }
}
