using UnityEngine;
using System.Collections;

public class SpawnOnDestroy : MonoBehaviour {
    public Transform prefab;

    void OnDestroy()
    {
        Instantiate(prefab, transform.position, Quaternion.identity);
    }
}
