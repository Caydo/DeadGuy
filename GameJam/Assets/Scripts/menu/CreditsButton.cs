using UnityEngine;
using System.Collections;

public class CreditsButton : MenuButton
{
  public ImageFader CreditsImageFader;
  public TextFader CreditsTextFader;

  public ImageFader[] ImageFaders;
  public TextFader[] TextFaders;

  public RectTransform CreditsText;

  protected override void doAction()
  {
    foreach(ImageFader imageFader in ImageFaders)
    {
      StartCoroutine(imageFader.FadeOut());
    }

    foreach(TextFader textFader in TextFaders)
    {
      StartCoroutine(textFader.FadeOut());
    }

    CreditsText.localPosition = new Vector3(0, -2, 0);

    StartCoroutine(CreditsImageFader.FadeIn());
    StartCoroutine(CreditsTextFader.FadeIn());
  }
}