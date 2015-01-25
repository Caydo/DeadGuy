using UnityEngine;
using System.Collections;

public class ActorMovement : MonoBehaviour
{
  public float forceAmount = 10;
  
  // Currently a good drag amount set for forceAmount of 10 is 6 on a 3D rigid body
  void Update()
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

    if (Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0)
    {
      rigidbody.velocity = Vector3.zero; ;
    }
   
	if(rigidbody.velocity != Vector3.zero)
	{
	  transform.rotation = Quaternion.LookRotation(rigidbody.velocity);
	}
  }
}