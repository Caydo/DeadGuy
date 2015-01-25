using UnityEngine;
using System.Collections;

public class CreditsButton : MenuButton
{
  public GameObject CreditsText;
  public GameObject Buttons;
  protected override void doAction()
  {
    CreditsText.SetActive(true);
    Buttons.SetActive(false);
  }
}