using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private int initialSize = 10;
    [SerializeField] bool isExpandable = false;
    
    private Queue<GameObject> poolQueue = new Queue<GameObject>();

    void Awake()
    {
        if (prefab == null)
        {
            Debug.Log("Prefab must be referenced to use object pooling");
            return;
        }

        for(int i = 0; i < initialSize; i++)
        {
            AddObjectToPool();
        }
    }

    public GameObject GetObject()
    {
        if (poolQueue.Count > 0)
        {
            GameObject obj = poolQueue.Dequeue();
            obj.SetActive(true);
            return obj;
        }
        else if (isExpandable)
        {
            return AddObjectToPool();
        }
        else
        {
            Debug.Log("Pool is empty");
            return null;
        }
    }

    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
        poolQueue.Enqueue(obj);
    }

    public GameObject AddObjectToPool()
    {
        GameObject obj = Instantiate(prefab, transform);
        obj.SetActive(false);
        poolQueue.Enqueue(obj);

        return obj;
    }
}
