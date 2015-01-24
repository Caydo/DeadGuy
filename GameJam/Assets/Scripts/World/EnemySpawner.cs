using UnityEngine;
using System.Collections;
using System;

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

  public void Spawn()
  {
    HasSpawned = true;
    if (Sequential)
    {
      foreach (var enemy in Enemies)
      {
        enemy.gameObject.SetActive(true);
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
    foreach(var enemy in Enemies)
    {
      if(enemy.HP <= 0)
      {

      }
    }

    if(dead < Enemies.Length)
    {
      if(inPlay < MaxInPlay)
      {
        var enemy = getNextEnemy();
      }

    }
  }

  private Actor getNextEnemy()
  {
    var retVal = Enemies[spawned];
    ++spawned;
    ++inPlay;
    return retVal;
  }


  
}
