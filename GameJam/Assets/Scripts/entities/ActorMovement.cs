using UnityEngine;
using System.Collections;

public class ActorMovement : MonoBehaviour
{
  public bool IsPlayer;
  
  void Update()
  {
    if(IsPlayer)
    {
      if(Input.GetKeyUp(KeyCode.UpArrow))
      {
        // go up
      }
      
      if(Input.GetKeyUp(KeyCode.DownArrow))
      {
        // go down
      }
      
      if(Input.GetKeyUp(KeyCode.LeftArrow))
      {
        // go left
      }
      
      if(Input.GetKeyUp(KeyCode.RightArrow))
      {
        // go right
      }
    }
    else
    {
      // look for player
      // if player is in range of attack then attempt to attack, otherwise move toward the player and then try to attack again, rinse and repeat
    }
  }
}