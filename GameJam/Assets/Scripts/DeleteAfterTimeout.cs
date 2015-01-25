using UnityEngine;
using System.Collections;

public class DeleteAfterTimeout : MonoBehaviour {
	public float lifespan = 5.0f;

	void Start() {
		StartCoroutine(Delete());
	}

	IEnumerator Delete() {
		yield return new WaitForSeconds(lifespan);
		Destroy(gameObject);
	}
}
