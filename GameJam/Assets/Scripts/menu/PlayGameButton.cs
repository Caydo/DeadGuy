using UnityEngine;
using System.Collections;

public class PlayGameButton : MenuButton
{
  protected override void doAction()
  {
    Application.LoadLevel("Level");
  }
}