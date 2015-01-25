using UnityEngine;
using System.Collections;

public class Actor : MonoBehaviour
{
  public int HP;
  public int Attack;
  public int Defense;
  public float MeleeAttackSpeed;
  public float RangedAttackSpeed;
  public bool IsPlayer;

  public bool IsDead()
  {
    return HP <= 0;
  }
}