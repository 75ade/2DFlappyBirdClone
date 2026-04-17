using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Detector : MonoBehaviour
{
    [SerializeField] private ScoreView scoreView;
    private AudioManager audioManager;
    private BirdMovement birdMovement;

    void Awake()
    {
        audioManager = FindFirstObjectByType<AudioManager>();
        birdMovement = GetComponent<BirdMovement>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!birdMovement.GetIsAlive()) return;

        switch (collision.gameObject.tag)
        {
            case "Surface":
                birdMovement.SetIsAlive(false);
                audioManager.PlayHitSFX();
                StartCoroutine(LoadScene(sceneName: "GameOverScene"));   
                break;
                
            case "Pipe":
                birdMovement.SetIsAlive(false);
                audioManager.PlayHitSFX();
                audioManager.PlayDieSFX();
                StartCoroutine(LoadScene(sceneName: "GameOverScene"));    
                break;
        }
    }

    IEnumerator LoadScene(string sceneName)
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneName);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pipe"))
        {
            scoreView.SetScore();
            audioManager.PlayScoreSFX();
        }
    }
}