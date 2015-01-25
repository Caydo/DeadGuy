using UnityEngine;
using System.Collections;

public class FinalBoss : MonoBehaviour
{
  Actor actor;
  bool gameWon = false;

  void Start()
  {
    actor = GetComponent<Actor>();
  }

  void Update()
  {
    if(!gameWon && actor.IsDead())
    {
      gameWon = true;
      // win game here!
      GameObject.FindObjectOfType<GameController>().WinGame();
    }
  }
}