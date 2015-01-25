﻿using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {
    public float secondsBetweenAttacks = 0.5f;
    public float duration = 3.0f;
    public float meleeRange = 2.0f;
    public Bullet meleePrefab;
    public Bullet rangedPrefab;
    
    RandomAI ai;
    Transform player;
    bool melee = false;
    
    void Awake() {
        ai = transform.GetComponentInParent<RandomAI>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    
    void OnEnable() {
        melee = Vector3.Distance(player.position, transform.position) < meleeRange;
        StartCoroutine(NextAfterTimeout());
        StartCoroutine(RunAttacks());
    }
    
    IEnumerator NextAfterTimeout() {
        yield return new WaitForSeconds(duration);
        ai.DoSomethingRandom();
    }

    IEnumerator RunAttacks() {
        while (true) {
            Vector3 bulletSpawnPosition = transform.position + (transform.position - player.position).normalized;

            Transform toSpawn = null;
            if (melee) {
                ai.animator.SetBool("Melee", true);
                toSpawn = meleePrefab.transform;
            } else {
                ai.animator.SetBool("Melee", true);
                toSpawn = rangedPrefab.transform;
            }

            Bullet bullet = (Instantiate(toSpawn, bulletSpawnPosition, Quaternion.LookRotation(bulletSpawnPosition)) as Transform).GetComponent<Bullet>();
            bullet.SourceActor = ai.actor;

            yield return new WaitForSeconds(secondsBetweenAttacks);
        }
    }
}
