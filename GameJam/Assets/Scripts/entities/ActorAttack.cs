using UnityEngine;
using System.Collections;

public class ActorAttack : MonoBehaviour
{
  public GameObject AttackOnePrefab;
  public GameObject AttackTwoPrefab;

  public Transform AttackOnePosition;
  public Transform AttackTwoPosition;
  
  void Update()
  {
    if(Input.GetButton("Fire1"))
    {
      // attack one
      GameObject.Instantiate(AttackOnePrefab, AttackOnePosition.position, Quaternion.identity);
    }

    if(Input.GetButton("Fire2"))
    {
      // attack two
      GameObject.Instantiate(AttackTwoPrefab, AttackOnePosition.position, Quaternion.identity);
    }
  }
}