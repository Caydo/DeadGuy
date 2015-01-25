using UnityEngine;
using System.Collections;

public class Strafe : MonoBehaviour {
    public float speed = 10.0f;
    public float duration;

	RandomAI ai;
	Transform player;
	float awakeTime;

	void Awake() {
		ai = transform.GetComponentInParent<RandomAI>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void OnEnable() {
		awakeTime = Time.time;
	}
	
	void Update() {
		if (Time.time > awakeTime + duration) {
			ai.DoSomethingRandom();
		}
        Vector3 towards = player.position - transform.position;
        ai.rigidbody.AddForce(Vector3.Cross(towards, Vector3.up).normalized * speed);
	}
}
