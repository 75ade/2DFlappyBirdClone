using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartView : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private Button playButton;
    [SerializeField] private Button quitButton;

    private AudioManager audioManager;

    void Awake()
    {
        audioManager = FindFirstObjectByType<AudioManager>();
    }

    void OnEnable()
    {
        playButton.onClick.AddListener(OnPlayPressed);
        quitButton.onClick.AddListener(OnQuitPressed);
    }

    private void OnPlayPressed()
    {
        audioManager.PlaySwooshSFX();
        SceneManager.LoadScene("GameScene");
    }

    private void OnQuitPressed()
    {
        Application.Quit();
    }    
}
