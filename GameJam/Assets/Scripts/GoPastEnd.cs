using UnityEngine;
using System.Collections;

public class GoPastEnd : MonoBehaviour
{
  public TextFader IntroTextFader;
  public EndTextCrawl TextCrawler;

  public void EndTextClicked()
  {
    StartCoroutine(fadeThenWait());
  }

  IEnumerator fadeThenWait()
  {
    StartCoroutine(IntroTextFader.FadeOut());
    while (!IntroTextFader.Done)
    {
      yield return null;
    }

    Application.LoadLevel("MainMenu");
  }
}