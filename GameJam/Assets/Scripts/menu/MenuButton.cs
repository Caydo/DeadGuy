using UnityEngine;
using System.Collections;

public class MenuButton : MonoBehaviour
{
  void OnMouseUp()
  {
    doAction();
  }

  protected virtual void doAction()
  {
    // override me
  }
}