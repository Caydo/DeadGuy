using UnityEngine;
using System.Collections;

public class BulletCollider : MonoBehaviour
{
  public Actor SourceActor;
  public string EnemyTag;
  
  void OnTriggerEnter(Collider objectThatCollided)
  {
    if (objectThatCollided.gameObject.tag == EnemyTag)
    {
      Actor enemyActor = objectThatCollided.gameObject.GetComponent<Actor>();
      int attackDamage = (SourceActor.Attack - enemyActor.Defense);
      enemyActor.HP -= (attackDamage > 0) ? attackDamage : 0;
    }
  }
}
