using UnityEngine;
using System.Collections;

public class FinalBoss : MonoBehaviour
{
  Actor actor;

  void Start()
  {
    actor = GetComponent<Actor>();
  }

  void Update()
  {
    if( actor.IsDead())
    {
      GameObject.FindObjectOfType<GameController>().WinGame();
    }
  }
}