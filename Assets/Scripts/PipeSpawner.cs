using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private ObjectPool pipePool;
    [SerializeField] private float spawnRate = 2f;

    [SerializeField] private GameObject surface;
    [SerializeField] private Camera mainCamera;

    [Header("Gap Setting")]
    [SerializeField] private float margin = 10f;
    [SerializeField] private float gapSize = 1.7f;

    private float timer;
    private float minY;
    private float maxY;

    private BirdMovement birdMovement;

    void Awake()
    {
        birdMovement = FindFirstObjectByType<BirdMovement>();
    }

    void Update()
    {
        if (!birdMovement.GetIsAlive()) return;

        timer += Time.deltaTime;

        if (timer >= spawnRate)
        {
            timer = 0;
            GameObject pipe = pipePool.GetObject();
            pipe.transform.SetPositionAndRotation(GenerateRandomYPostion(), transform.rotation);
        }
    }

    Vector2 GenerateRandomYPostion()
    {
        minY = surface.transform.position.y + gapSize + margin;
        maxY = mainCamera.orthographicSize - gapSize - margin;
        float randomY = Random.Range(minY, maxY);

        return new Vector2(transform.position.x, randomY);
    }
}
