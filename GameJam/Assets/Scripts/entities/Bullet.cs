using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
  public bool IsRanged;
  public float killTime;
  public Actor SourceActor;
  public GameObject BulletColliderGO;
  BulletCollider bulletCollider;

  bool fired = false;
  float forceAmount = 100;
  string EnemyTag = string.Empty;

	void OnEnable()
  {
    if(!fired)
    {
      fired = true;
      StartCoroutine(waitForSourceActor());
    }
  }

  IEnumerator waitThenDestroy()
  {
    yield return new WaitForSeconds(killTime);
    GameObject.Destroy(gameObject);
  }

  IEnumerator waitForSourceActor()
  {
    while(SourceActor == null)
    {
      yield return null;
    }

    bulletCollider = BulletColliderGO.GetComponent<BulletCollider>();
    bulletCollider.SourceActor = SourceActor;
    bulletCollider.EnemyTag = (SourceActor.IsPlayer) ? "Enemy" : "Player";

    StartCoroutine(waitThenDestroy());

    if (IsRanged)
    {
      Vector3 movementForce = new Vector3(0, forceAmount, 0);
      rigidbody.AddForce(movementForce);
    }
  }
}