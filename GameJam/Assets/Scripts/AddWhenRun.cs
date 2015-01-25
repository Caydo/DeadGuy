using UnityEngine;
using System.Collections;

public class AddWhenRun : MonoBehaviour
{
	public GameObject prefab;
	// Use this for initialization
	void Start () {
		var instance = GameObject.Instantiate (prefab) as GameObject;
		instance.transform.parent = transform;
		instance.transform.rotation = Quaternion.identity;
		instance.transform.localPosition = Vector3.back;
	}
}
