using UnityEngine;
using System.Collections;
using System;

public class LevelController : MonoBehaviour 
{
  public ObjectSpawner[] ObjectSpawnPairs;
	// Use this for initialization
	void Start () 
  {
	
	}
	
	// Update is called once per frame
	void Update () 
  {
    foreach (var spawn in ObjectSpawnPairs)
    {
      if (spawn.Interactable.Used && !spawn.Spawner.HasSpawned)
      {
        spawn.Spawner.Spawn();
      }
    }
	}

  [Serializable]
  public class ObjectSpawner
  {
    public InteractableObject Interactable;
    public EnemySpawner Spawner;
  }
}
