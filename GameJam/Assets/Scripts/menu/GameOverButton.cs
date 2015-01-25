using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverButton : MenuButton
{
  public ImageFader ImageFader;
  public TextFader TextFader;
  public Image CurrentImage;

  void Awake()
  {
    TextForButton = "Game Over\n\nClick Here To\nReturn To The Main Menu";
  }

  protected override void doAction()
  {
    StartCoroutine(waitforFadeThenLeave());
  }

  IEnumerator waitforFadeThenLeave()
  {
    StartCoroutine(ImageFader.FadeOut());
    StartCoroutine(TextFader.FadeOut());

    while(CurrentImage.color.a > 0)
    {
      yield return null;
    }

    Application.LoadLevel("MainMenu");
  }
}