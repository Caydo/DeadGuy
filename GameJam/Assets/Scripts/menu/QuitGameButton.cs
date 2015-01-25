using UnityEngine;
using System.Collections;

public class QuitGameButton : MenuButton
{
  protected override void doAction()
  {
    Application.Quit();
  }
}