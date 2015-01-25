using UnityEngine;
using System.Collections;

public class ActorAttack : MonoBehaviour
{
  public GameObject AttackOnePrefab;
  public GameObject AttackTwoPrefab;

  public Transform AttackOnePosition;
  public Transform AttackTwoPosition;

  int bulletsLaunched = 0;

  void Update()
  {
    if(Input.GetButton("Fire1"))
    {
      // attack one
      GameObject attack1 = (GameObject)GameObject.Instantiate(AttackOnePrefab, AttackOnePosition.position, Quaternion.identity);
      Bullet attackBullet = attack1.GetComponent<Bullet>();
      if(attackBullet.IsRanged)
      {
        bulletsLaunched++;
      }
      attackBullet.SourceActor = GetComponent<Actor>();
    }

    if(Input.GetButton("Fire2"))
    {
      // attack two
      GameObject attack2 = (GameObject)GameObject.Instantiate(AttackTwoPrefab, AttackTwoPosition.position, Quaternion.identity);
      Bullet attackBullet = attack2.GetComponent<Bullet>();
      if(attackBullet.IsRanged)
      {
        bulletsLaunched++;
      }
      attack2.GetComponent<Bullet>().SourceActor = GetComponent<Actor>();
    }
  }
}