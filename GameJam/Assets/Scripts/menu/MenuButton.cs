using UnityEngine;
using System.Collections;

public class MenuButton : MonoBehaviour
{
  public TextMesh Text;
  public string TextForButton;

  void Start()
  {
    Text.text = TextForButton;
  }

  void OnMouseUp()
  {
    doAction();
  }

  protected virtual void doAction()
  {
    // override me
  }
}