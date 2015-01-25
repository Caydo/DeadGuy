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
  Player player;

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
    player = GameObject.FindObjectOfType<Player>();
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
        Debug.Log(string.Format("isboss [{0}] count [{1}]", spawn.Spawner.IsBoss, player.HorcruxCount));
        if (!spawn.Spawner.IsBoss || (spawn.Spawner.IsBoss && player.HorcruxCount >= 4))
        {
          spawn.Spawner.Spawn();
        }
      }
    }

    //foreach(var thing in ObjectSpawnPairs)
    //{
    //  if(!thing.Required)
    //  {
    //    continue;
    //  }
    //  else if(thing.Interactable.Used && thing.Spawner.AllDead)
    //  {
    //    LevelComplete = true;
    //  }
    //  else
    //  {

    //  }
    //}

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
