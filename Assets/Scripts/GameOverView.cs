using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverView : MonoBehaviour
{   
    [Header("UI References")]
    [SerializeField] private TMP_Text highScoreText;
    [SerializeField] private Button tryAgainButton;
    [SerializeField] private Button menuButton;

    [Header("Score References")]
    private ScoreManager scoreManager;

    private int highScore;

    void Awake()
    {
        scoreManager = FindFirstObjectByType<ScoreManager>();
    }

    void OnEnable()
    {
        tryAgainButton.onClick.AddListener(OnTryAgainPressed);
        menuButton.onClick.AddListener(OnMenuPressed);
    }

    void Start()
    {
        highScore = scoreManager.GetScore();
        highScoreText.text = $"Highest score: {highScore}";
    }

    void OnTryAgainPressed()
    {
        scoreManager.ResetScore();
        SceneManager.LoadScene("GameScene");
    }

    void OnMenuPressed()
    {
        scoreManager.ResetScore();
        SceneManager.LoadScene("StartScene");
    }
}
