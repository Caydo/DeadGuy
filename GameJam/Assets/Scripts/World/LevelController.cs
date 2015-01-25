using UnityEngine;
using System.Collections;
using System;
using System.Linq;
using Assets.Scripts.World;
using System.Collections.Generic;

public class LevelController : MonoBehaviour 
{
  public ObjectSpawner[] ObjectSpawnPairs;
  public bool LevelComplete = false;
  public LevelExit Exit;
  public int ExitTo;
  List<LevelExit> exits;

  public bool Exiting
  {
    get
    {
      return Exit != null && Exit.Exiting;
    }
  }

  void Start()
  {
    exits = GetComponentsInChildren<LevelExit>().ToList();
    
  }

	// Update is called once per frame
	void Update () 
  {
    Exit = null;
    foreach (var exit in exits)
    {
      if(exit.Exiting)
      {
        Exit = exit;
        break;
      }
    }
    foreach (var spawn in ObjectSpawnPairs)
    {
      if (spawn.Interactable.Used && !spawn.Spawner.HasSpawned)
      {
        spawn.Spawner.Spawn();
      }
    }

    if (ObjectSpawnPairs.All(pair => !pair.Required || (pair.Required && pair.Interactable.Used && pair.Spawner != null && pair.Spawner.AllDead)))
    {
      LevelComplete = true;
    }
	}

  [Serializable]
  public class ObjectSpawner
  {
    public InteractableObject Interactable;
    public EnemySpawner Spawner;
    public bool Required;
  }
}
