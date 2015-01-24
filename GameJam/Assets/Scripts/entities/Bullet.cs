using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
  public bool IsRanged;
  public float killTime;
  bool fired = false;
  float forceAmount = 100;

	void OnEnable()
  {
    if(!fired)
    {
      StartCoroutine(waitThenDestroy());
      fired = true;

      if(IsRanged)
      {
        Vector3 movementForce = new Vector3(0, forceAmount, 0);
        rigidbody.AddForce(movementForce);
      }
    }
  }

  IEnumerator waitThenDestroy()
  {
    yield return new WaitForSeconds(killTime);
    GameObject.Destroy(gameObject);
  }
}