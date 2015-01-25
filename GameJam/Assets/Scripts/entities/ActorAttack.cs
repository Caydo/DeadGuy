using UnityEngine;
using System.Collections;

public class ActorAttack : MonoBehaviour
{
  public Bullet AttackOnePrefab;
  public Bullet AttackTwoPrefab;
  public Transform AttackOnePosition;
  public Transform AttackTwoPosition;

  bool canFireAttack1 = true;
  bool canFireAttack2 = true;

  void Update()
  {
    if(Input.GetButtonDown("Fire1") && canFireAttack1)
    {
      Bullet attackBullet = GameObject.Instantiate(AttackOnePrefab, AttackOnePosition.position, Quaternion.identity) as Bullet;
      attackBullet.SourceActor = GetComponent<Actor>();
      StartCoroutine(waitToFireAgain(true));
    }

    if(Input.GetButtonDown("Fire2") && canFireAttack2)
    {
      // attack two
      Bullet attackBullet = GameObject.Instantiate(AttackTwoPrefab, AttackTwoPosition.position, Quaternion.identity) as Bullet;
      attackBullet.SourceActor = GetComponent<Actor>();
      StartCoroutine(waitToFireAgain(false));
    }
  }
  
  IEnumerator waitToFireAgain(bool isAttackOne)
  {
    Actor actor = GetComponent<Actor>();
    if(isAttackOne)
    {
      canFireAttack1 = false;
      yield return new WaitForSeconds(actor.MeleeAttackSpeed);
      canFireAttack1 = true;
    }
    else
    {
      canFireAttack2 = false;
      yield return new WaitForSeconds(actor.RangedAttackSpeed);
      canFireAttack2 = true;
    }
  }
}