using UnityEngine;
using System.Collections;

public class ActorAttack : MonoBehaviour
{
  public Bullet AttackOnePrefab;
  public Bullet AttackTwoPrefab;

  public Transform AttackOnePosition;
  public Transform AttackTwoPosition;
    
  void Update()
  {
    if(Input.GetButtonDown("Fire1"))
    {
      Bullet attackBullet = GameObject.Instantiate(AttackOnePrefab, AttackOnePosition.position, Quaternion.identity) as Bullet;
      attackBullet.SourceActor = GetComponent<Actor>();
    }

    if(Input.GetButtonDown("Fire2"))
    {
      // attack two
      Bullet attackBullet = GameObject.Instantiate(AttackTwoPrefab, AttackTwoPosition.position, Quaternion.identity) as Bullet;
      attackBullet.SourceActor = GetComponent<Actor>();
    }
  }
}