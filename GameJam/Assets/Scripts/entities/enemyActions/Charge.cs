using UnityEngine;
using System.Collections;

public class Charge : MonoBehaviour
{
    public float speed = 10.0f;
    public float duration = 3.0f;

    RandomAI ai;
    Transform player;
    float awakeTime;

    void Awake()
    {
        ai = transform.GetComponentInParent<RandomAI>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void OnEnable()
    {
        awakeTime = Time.time;
        ai.animator.walking = true;
    }

    void OnDisable()
    {
        ai.animator.walking = false;
    }

    void Update()
    {
        if (Time.time > awakeTime + duration)
        {
            ai.DoSomethingRandom();
        }
        Vector3 towards = player.position - transform.position;
        ai.actor.rigidbody.AddForce(towards.normalized * speed);
    }
}
