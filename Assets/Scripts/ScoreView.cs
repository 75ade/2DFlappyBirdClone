using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] TMP_Text scoreText;
    
    private ScoreManager scoreManager;

    void Awake()
    {
        scoreManager = FindFirstObjectByType<ScoreManager>();
    }

    void Start()
    {
        scoreText.text = "Score: 0";
    }

    public void SetScore()
    {
        scoreManager.AddToScore();
        scoreText.text = $"Score: {scoreManager.GetScore()}";
    }
}
