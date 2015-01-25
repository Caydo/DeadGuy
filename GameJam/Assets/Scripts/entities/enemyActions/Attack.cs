using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour
{
    public float secondsBetweenAttacks = 0.5f;
    public float duration = 3.0f;
    public float meleeRange = 2.0f;
    public Bullet meleePrefab;
    public Bullet rangedPrefab;

    RandomAI ai;
    Transform player;
    bool melee = false;
    float awakeTime;

    void Awake()
    {
        ai = transform.GetComponentInParent<RandomAI>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void OnEnable()
    {
        melee = Vector3.Distance(player.position, transform.position) < meleeRange;
        StartCoroutine(RunAttacks());
        awakeTime = Time.time;
        ai.animator.attacking = true;
    }

    void OnDisable()
    {
        ai.animator.attacking = false;
    }

    void Update()
    {
        if (Time.time > awakeTime + duration)
        {
            ai.DoSomethingRandom();
        }
    }

    IEnumerator RunAttacks()
    {
        while (true)
        {
            Vector3 bulletSpawnPosition = transform.position - (transform.position - player.position).normalized;

            Transform toSpawn = null;
            if (melee)
            {
                toSpawn = meleePrefab.transform;
            }
            else
            {
                toSpawn = rangedPrefab.transform;
            }

            Bullet bullet = (Instantiate(toSpawn, bulletSpawnPosition, Quaternion.LookRotation(bulletSpawnPosition)) as Transform).GetComponent<Bullet>();
            bullet.SourceActor = ai.actor;

            yield return new WaitForSeconds(secondsBetweenAttacks);
        }
    }
}
