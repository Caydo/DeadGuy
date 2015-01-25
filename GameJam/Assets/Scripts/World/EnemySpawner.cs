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
  public bool HasSpawned;

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

  void Update()
  {
    //clean up enemies
    for (int i = spawnedEnemies.Count; i >= 0; --i)
    {
      if (spawnedEnemies[i].IsDead())
      {
        ++dead;
        --inPlay;
        spawnedEnemies.RemoveAt(i);
      }
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

    if (dead == Enemies.Length)
    {
      gameObject.SetActive(false);
      spawning = false;
    }
  }

  private Actor getNextEnemy()
  {
    var retVal = Enemies[spawned];
    spawnedEnemies.Add(retVal);
    ++spawned;
    ++inPlay;
    return retVal;
  }


  
}
