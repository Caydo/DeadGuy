﻿using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class ActorAttack : MonoBehaviour
{
  public ActionAnimator animator;

  public Bullet AttackOneBullet;
  public Bullet AttackTwoBullet;

  public Transform AttackOnePosition;
  public Transform AttackTwoPosition;
  public float MeleeAttackDistance;

  bool canFireAttack1 = true;
  bool canFireAttack2 = true;

  float attackTimeout = 0.0f;

  void Update()
  {
      attackTimeout -= Time.deltaTime;
      animator.attacking = attackTimeout > 0.0f;

    if(Input.GetButtonDown("Fire1") && canFireAttack1)
    {
      canFireAttack1 = false;
      Bullet attackBullet;
      if(AttackOneBullet.IsRanged)
      {
        attackBullet = GameObject.Instantiate(AttackOneBullet, gameObject.transform.position, gameObject.transform.rotation) as Bullet;
      }
      else
      {
        Vector3 mousePositionInWorldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 moveToPos = new Vector3(mousePositionInWorldPoint.x, mousePositionInWorldPoint.y, 0);
        moveToPos = Vector3.MoveTowards(gameObject.transform.position, moveToPos, MeleeAttackDistance);

        attackBullet = GameObject.Instantiate(AttackOneBullet, moveToPos, Quaternion.identity) as Bullet;
      }

      attackBullet.SourceActor = GetComponent<Actor>();
      attackTimeout = 1.0f;
      StartCoroutine(waitToFireAgain(true));
    }

    if(Input.GetButtonDown("Fire2") && canFireAttack2)
    {
      canFireAttack2 = false;
      Bullet attackBullet;
      if(AttackTwoBullet.IsRanged)
      {
        attackBullet = GameObject.Instantiate(AttackTwoBullet, gameObject.transform.position, gameObject.transform.rotation) as Bullet;
      }
      else
      {
        Vector3 mousePositionInWorldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 moveToPos = new Vector3(mousePositionInWorldPoint.x, mousePositionInWorldPoint.y, 0);
        moveToPos = Vector3.MoveTowards(gameObject.transform.position, moveToPos, MeleeAttackDistance);

        attackBullet = GameObject.Instantiate(AttackTwoBullet, moveToPos, Quaternion.identity) as Bullet;
      }
      
      attackBullet.SourceActor = GetComponent<Actor>();
      attackTimeout = 1.0f;
      StartCoroutine(waitToFireAgain(false));
    }
  }
  
  IEnumerator waitToFireAgain(bool isAttackOne)
  {
    Actor actor = GetComponent<Actor>();
    if(isAttackOne)
    {
      yield return new WaitForSeconds(actor.MeleeAttackSpeed);
      canFireAttack1 = true;
    }
    else
    {
      yield return new WaitForSeconds(actor.RangedAttackSpeed);
      canFireAttack2 = true;
    }
  }
}