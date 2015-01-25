using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CreditsTextDisplayButton : MenuButton
{
  void Awake()
  {
    TextForButton = "Credits:\n\nKennan - Art\n\nKaitlyn - Programming/Art\n\nLewis - Programming\n\nJoe - Programming\n\nShad - Art/Programming";
  }

  public ImageFader CurrentImageFader;
  public TextFader CurrentTextFader;
  public ImageFader[] ImageFaders;
  public TextFader[] TextFaders;
  RectTransform rectTransform;
  Image currentImage;

  protected override void Start()
  {
    base.Start();
    currentImage = GetComponent<Image>();
    rectTransform = GetComponent<RectTransform>();
  }

  protected override void doAction()
  {
    StartCoroutine(CurrentImageFader.FadeOut());
    StartCoroutine(CurrentTextFader.FadeOut());

    StartCoroutine(waitforFadeThenMove());
  }

  IEnumerator waitforFadeThenMove()
  {
    while(currentImage.color.a > 0)
    {
      yield return null;
    }

    foreach(ImageFader imageFader in ImageFaders)
    {
       StartCoroutine(imageFader.FadeIn());
    }

    foreach(TextFader textFader in TextFaders)
    {
      StartCoroutine(textFader.FadeIn());
    }

    rectTransform.localPosition = new Vector3(1000, 1000, 1000);
  }
}