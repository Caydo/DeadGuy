using UnityEngine;
using System.Collections;

public class Strafe : MonoBehaviour {
    public float speed = 10.0f;
    public float duration;

    Transform player;

    void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnEnable() {
        StartCoroutine(NextAfterTimeout);
    }

	void Update () {
        Vector3 towards = player.position - transform.position;
        rigidbody.AddForce(Vector3.Cross(towards, Vector3.up).normalized * speed);
	}

    IEnumerable NextAfterTimeout() {
        yield return WaitForSeconds(duration);
        transform.GetComponentInParent<RandomAI>().DoSomethingRandom();
    }
}
