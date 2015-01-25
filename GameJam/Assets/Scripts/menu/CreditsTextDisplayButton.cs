using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CreditsTextDisplayButton : MenuButton
{
  void Awake()
  {
    TextForButton = "Credits:\n\nKenan Jackson - Art\nKaitlyn Culley - Programming/Art\nLewis Broerman - Programming\nJoseph Smits - Programming\nShad Tischer - Programming/Art\n\nClick To Continue";
    TextForButton2 = "Audio Special Thanks:\n\nMike Koenig\nCGeffex\nNeoPhyTe\nMark DiAngelo\nSoundBible.com\n\nClick To Continue";
  }

  public string TextForButton2;
  public ImageFader CurrentImageFader;
  public TextFader CurrentTextFader;
  public ImageFader[] ImageFaders;
  public TextFader[] TextFaders;
  RectTransform rectTransform;
  Image currentImage;
  bool shownAudio = false;

  public void SetInitialCreditsText()
  {
    shownAudio = false;
    UIText.text = TextForButton;
  }

  protected override void Start()
  {
    base.Start();
    currentImage = GetComponent<Image>();
    rectTransform = GetComponent<RectTransform>();
  }

  protected override void doAction()
  {
    if(shownAudio)
    {
      StartCoroutine(CurrentImageFader.FadeOut());
      StartCoroutine(CurrentTextFader.FadeOut());

      StartCoroutine(waitforFadeThenMove());
    }
    else
    {
      UIText.text = TextForButton2;
      shownAudio = true;
    }
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