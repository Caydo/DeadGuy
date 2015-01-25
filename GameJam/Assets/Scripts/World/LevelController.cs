using UnityEngine;
using System.Collections;
using System;
using System.Linq;

public class LevelController : MonoBehaviour 
{
  public ObjectSpawner[] ObjectSpawnPairs;
  public InteractableObject[] RequiredInteractions;
  public bool LevelComplete = false;
	
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

    if(RequiredInteractions.All(ri => ri.Used))
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
