using UnityEngine;
using System.Collections;

public class CreditsTextDisplayButton : MenuButton
{
  public GameObject Buttons;
  void Awake()
  {
    TextForButton = "Credits:\n\nKennan - Art\n\nKaitlyn - Programming/Art\n\nLewis - Programming\n\nJoe - Programming\n\nShad - Art/Programming";
  }

  protected override void doAction()
  {
    Buttons.SetActive(true);
    gameObject.SetActive(false);
  }
}