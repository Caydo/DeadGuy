using UnityEngine;
using System.Collections;

public class GoPastIntro : MonoBehaviour
{
  public TextFader IntroTextFader;
  public TextCrawl TextCrawler;

  public void IntroTextClicked()
  {
    StartCoroutine(fadeThenWait());
  }

  IEnumerator fadeThenWait()
  {
    StartCoroutine(IntroTextFader.FadeOut());
    while(!IntroTextFader.Done)
    {
      yield return null;
    }

    Application.LoadLevel("Level");
  }
}