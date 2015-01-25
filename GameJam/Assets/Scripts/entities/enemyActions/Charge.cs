using UnityEngine;
using System.Collections;

public class Charge : MonoBehaviour {
    public float speed = 10.0f;
    public float duration = 3.0f;

    RandomAI ai;
    Transform player;

    void Awake() {
        ai = transform.GetComponentInParent<RandomAI>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void OnEnable() {
        StartCoroutine(NextAfterTimeout());
    }

	void Update() {
        Vector3 towards = player.position - transform.position;
        rigidbody.AddForce(towards.normalized * speed);
	}

    IEnumerator NextAfterTimeout() {
        yield return new WaitForSeconds(duration);
		ai.DoSomethingRandom();
    }
}
