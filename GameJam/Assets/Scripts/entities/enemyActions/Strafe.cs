using UnityEngine;
using System.Collections;

public class Strafe : MonoBehaviour {
    public float speed = 10.0f;
    public float duration;

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
        rigidbody.AddForce(Vector3.Cross(towards, Vector3.up).normalized * speed);
	}

    IEnumerator NextAfterTimeout() {
        yield return new WaitForSeconds(duration);
        ai.DoSomethingRandom();
    }
}
