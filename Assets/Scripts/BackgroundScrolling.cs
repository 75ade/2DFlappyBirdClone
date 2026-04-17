using UnityEngine;

public class BackgroundScrolling : MonoBehaviour
{
    [SerializeField] private Vector2 moveSpeed;
    private Vector2 offset;

    private Material material;

    private BirdMovement birdMovement;

    void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
        birdMovement = FindFirstObjectByType<BirdMovement>();
    }

    void Update()
    {
        if (!birdMovement.GetIsAlive()) return;
    
        // offset += moveSpeed * Time.deltaTime;
        offset += moveSpeed;
        material.mainTextureOffset = offset;
    }
}
