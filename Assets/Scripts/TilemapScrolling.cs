using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapScrolling : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 900f;

    private Rigidbody2D tileRB;

    private BirdMovement birdMovement;

    void Awake()
    {
        tileRB = GetComponent<Rigidbody2D>();
        birdMovement = FindFirstObjectByType<BirdMovement>();
    }

    // void Update()
    // {
    //     tileRB.linearVelocity = new Vector2(-moveSpeed * Time.deltaTime, tileRB.linearVelocity.y);

    //     if (gameObject.transform.position.x == -18f)
    //     {
    //         Debug.Log("Reset surface's position");
    //         gameObject.transform.position = new Vector2(0f, 0f);
    //     }
    // }

    void Update()
    {
        if (!birdMovement.GetIsAlive())
        {
            tileRB.linearVelocity = new Vector2(0, tileRB.linearVelocity.y);
            return;
        }

        MoveTileMap();
    }

    private void MoveTileMap()
    {
        // tileRB.linearVelocity = new Vector2(-moveSpeed * Time.deltaTime, tileRB.linearVelocity.y);
        
        tileRB.linearVelocity = new Vector2(-moveSpeed, tileRB.linearVelocity.y);

        if (gameObject.transform.position.x <= -18f)
        {
            gameObject.transform.position = new Vector2(0f, 0f);
        }
    }

}
