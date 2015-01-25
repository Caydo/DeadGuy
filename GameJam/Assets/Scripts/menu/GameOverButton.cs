using UnityEngine;
using System.Collections;

public class GameOverButton : MenuButton
{
  protected override void doAction()
  {
    Application.LoadLevel("MainMenu");
  }
}