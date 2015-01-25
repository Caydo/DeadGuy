using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
  public bool IsRanged;
  public float killTime;
  public Actor SourceActor;
  public GameObject BulletColliderGO;
  public bool Done
  {
    get;
    private set;
  }

  BulletCollider bulletCollider;

  bool fired = false;
  public float forceAmount;

	void OnEnable()
  {
    Done = false;
    if(!fired)
    {
      fired = true;
      StartCoroutine(waitForSourceActor());
    }
  }

  IEnumerator waitThenDestroy()
  {
    yield return new WaitForSeconds(killTime);
    Done = true;
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
    Vector3 mousePositionInWorldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    mousePositionInWorldPoint.z = 0;
    Vector3 objectPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0);
    Vector3 moveToPos = (mousePositionInWorldPoint - gameObject.transform.position).normalized;
    StartCoroutine(waitThenDestroy());

    if(IsRanged)
    {
      rigidbody.AddForce(moveToPos * forceAmount);
    }
    else
    {
      
    }
  }
}