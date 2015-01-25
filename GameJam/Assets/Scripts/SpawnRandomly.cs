using UnityEngine;
using System.Collections;

public class SpawnRandomly : MonoBehaviour {
    public Transform prefab;
    public float minSeconds;
    public float maxSeconds;

    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minSeconds, maxSeconds));
            Instantiate(prefab, transform.position, Quaternion.identity);
        }
    }
}