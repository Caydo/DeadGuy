using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Actor))]
public class SpawnWhenHPDrops : MonoBehaviour
{
    public Transform prefab;

    Actor actor;
    int oldHP;

    void Awake()
    {
        actor = GetComponent<Actor>();
        oldHP = actor.HP;
    }

    void Update()
    {
        if (actor.HP < oldHP)
        {
            Instantiate(prefab, transform.position, Quaternion.identity);
        }

        oldHP = actor.HP;
    }
}