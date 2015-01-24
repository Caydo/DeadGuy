using UnityEngine;
using System.Collections;

public class ActorMovement : MonoBehaviour
{
  public bool IsPlayer;
  float forceAmount = 10;

  void Update()
  {
    if(IsPlayer)
    {
      // go left
      if(Input.GetAxis("Horizontal") < 0)
      {
        Vector3 movementForce = new Vector3(-forceAmount, 0, 0);
        rigidbody.AddForce(movementForce);
      }

      // go right
      if(Input.GetAxis("Horizontal") > 0)
      {
        Vector3 movementForce = new Vector3(forceAmount, 0, 0);
        rigidbody.AddForce(movementForce);
      }

      // go up
      if(Input.GetAxis("Vertical") > 0)
      {
        Vector3 movementForce = new Vector3(0, forceAmount, 0);
        rigidbody.AddForce(movementForce);
      }

      // go down
      if(Input.GetAxis("Vertical") < 0)
      {
        Vector3 movementForce = new Vector3(0, -forceAmount, 0);
        rigidbody.AddForce(movementForce);
      }
    }
    else
    {
      // look for player
      // if player is in range of attack then attempt to attack, otherwise move toward the player and then try to attack again, rinse and repeat
    }
  }
}