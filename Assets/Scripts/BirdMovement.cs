using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class BirdMovement : MonoBehaviour
{
    [SerializeField] float jumpSpeed = 5f;
    private Rigidbody2D birdRB;
    private AudioManager audioManager;

    private bool isAlive = true;

    public bool GetIsAlive()
    {
        return isAlive;
    }

    public void SetIsAlive(bool liveState)
    {
        isAlive = liveState;
    }

    void Awake()
    {
        birdRB = gameObject.GetComponent<Rigidbody2D>();
        audioManager = FindFirstObjectByType<AudioManager>();
    }
    
    void OnMove()
    {
        if (isAlive)
        {
            audioManager.PlayFlapSFX();
            birdRB.linearVelocity = new Vector2(birdRB.linearVelocity.x, jumpSpeed);
        }
    }
}
