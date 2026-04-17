using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    [Header("Pipe Setting")]
    [SerializeField] private float moveSpeed = 5f;
    
    
    [Header("Object Pooling")]
    [SerializeField] private float lifeTime = 3f;
    
    private ObjectPool objectPool;
    private float timer;
    
    private Rigidbody2D pipeRB;
    private BirdMovement birdMovement;

    void Awake()
    {
        pipeRB = gameObject.GetComponent<Rigidbody2D>();
        birdMovement = FindFirstObjectByType<BirdMovement>();
    }

    void OnEnable()
    {
        timer = 0f;
        objectPool = GetComponentInParent<ObjectPool>();
    }

    void Update()
    {
        if (!birdMovement.GetIsAlive()) 
        {
            pipeRB.linearVelocity = new Vector2(0, pipeRB.linearVelocity.y);
            return;
        }

        Move();
        timer += Time.deltaTime;

        if (timer >= lifeTime)
        {
            objectPool.ReturnObject(gameObject);
        }
    }

    void Move()
    {
        // pipeRB.linearVelocity = new Vector2(-moveSpeed * Time.deltaTime, pipeRB.linearVelocity.y);
        pipeRB.linearVelocity = new Vector2(-moveSpeed, pipeRB.linearVelocity.y);
    }
}
