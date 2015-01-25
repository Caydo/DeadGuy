using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.World
{
  [RequireComponent(typeof(BoxCollider))]
  public class LevelExit : MonoBehaviour
  {
    public int ExitLevel;
    public bool Exiting = false;
    public GameObject SpawnPoint;

    void OnTriggerEnter()
    {
      Exiting = true;
    }

    void OnTriggerExit()
    {
      Exiting = false;
    }
  }
}
