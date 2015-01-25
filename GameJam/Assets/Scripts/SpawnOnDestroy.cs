using UnityEngine;
using System.Collections;

public class SpawnOnDestroy : MonoBehaviour {
    public Transform prefab;

#if !UNITY_EDITOR
    void OnDestroy()
    {
        Instantiate(prefab, transform.position, Quaternion.identity);
    }
#endif
}
