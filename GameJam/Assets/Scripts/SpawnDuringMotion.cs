using UnityEngine;
using System.Collections;

public class SpawnDuringMotion : MonoBehaviour
{
    public Transform prefab;
    public float distance;

    Vector3 lastSpawnPosition;

    void Start()
    {
        lastSpawnPosition = transform.position;
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, lastSpawnPosition) > distance)
        {
            lastSpawnPosition = transform.position;
            Instantiate(prefab, transform.position, Quaternion.identity);
        }
    }
}