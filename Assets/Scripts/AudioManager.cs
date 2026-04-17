using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Flap SFX")]
    [SerializeField] private AudioClip flapClip;
    [SerializeField] [Range(0, 1)] private float flapVolume = 1f;

    [Header("Score SFX")]
    [SerializeField] private AudioClip scoreClip;
    [SerializeField] [Range(0, 1)] private float scoreVolume = 1f;

    [Header("Hit SFX")]
    [SerializeField] private AudioClip hitClip;
    [SerializeField] [Range(0, 1)] private float hitVolume = 1f;

    [Header("Swoosh SFX")]
    [SerializeField] private AudioClip swooshClip;
    [SerializeField] [Range(0, 1)] private float swooshVolume = 1f;

    [Header("Die SFX")]
    [SerializeField] private AudioClip dieClip;
    [SerializeField] [Range(0, 1)] private float dieVolume = 1f;

    private static AudioManager instance;

    void Awake()
    {
        InitSingleton();
    }

    private void InitSingleton()
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

    public void PlayAudioClip(AudioClip audioClip, float volume)
    {
        if (audioClip != null)
        {
            AudioSource.PlayClipAtPoint(audioClip, Camera.main.transform.position, volume);
        }
    }

    public void PlayFlapSFX()
    {
        PlayAudioClip(flapClip, flapVolume);
    }

    public void PlayScoreSFX()
    {
        PlayAudioClip(scoreClip, scoreVolume);
    }

    public void PlayHitSFX()
    {
        PlayAudioClip(hitClip, hitVolume);
    }

    public void PlaySwooshSFX()
    {
        PlayAudioClip(swooshClip, swooshVolume);
    }

    public void PlayDieSFX()
    {
        PlayAudioClip(dieClip, dieVolume);
    }
}
