using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
  public Text UIText;
  public string TextForButton;

  protected virtual void Start()
  {
    UIText.text = TextForButton;
  }

  public void Clicked()
  {
    doAction();
  }

  protected virtual void doAction()
  {
    // override me
  }
}