using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour {

  public Actor[] Enemies;
  public bool Sequential = false;
  public int MaxInPlay = 1;
  public float SequentialDelay = 0.0f;
  [NonSerialized]
  public bool HasSpawned = false;
  [NonSerialized]
  public bool AllDead = false;

  public bool IsBoss = false;

  int dead = 0;
  int inPlay = 0;
  int spawned = 0;
  bool spawning = false;
  readonly List<Actor> spawnedEnemies = new List<Actor>();

  public void Spawn()
  {
    HasSpawned = true;
    if (Sequential)
    {
      foreach (var enemy in Enemies)
      {
        enemy.gameObject.SetActive(true);
        spawnedEnemies.Add(enemy);
      }
    }
    else
    {
      spawning = true;
    }
  }
  List<Actor> remove = new List<Actor>();
  void Update()
  {
    remove.Clear();
    foreach(var enemy in spawnedEnemies)
    {
      if (enemy.IsDead())
      {
        ++dead;
        --inPlay;
        remove.Add(enemy);
      }
    }
    foreach(var enemey in remove)
    {
      spawnedEnemies.Remove(enemey);
    }

    if (spawning)
    {
      if (dead < Enemies.Length)
      {
        if (inPlay < MaxInPlay)
        {
          var enemy = getNextEnemy();
          enemy.gameObject.SetActive(true);
        }
      }
    }

    if (dead >= Enemies.Length)
    {
      if (!IsBoss)
        gameObject.SetActive(false);
      spawning = false;
      AllDead = true;
    }
  }

  private Actor getNextEnemy()
  {
    var retVal = Enemies[spawned];
    spawnedEnemies.Add(retVal);
    spawned = Math.Min(Enemies.Length - 1, spawned + 1);
    ++inPlay;
    return retVal;
  }


  
}
