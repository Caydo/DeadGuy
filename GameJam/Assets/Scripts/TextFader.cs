using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextFader : MonoBehaviour
{
  public bool FadeInOnStart = false;
  
  float AlphaAmount = 0.03f;
  public Text currentText;
  public bool Done = false;
  float cachedAlpha = 0;
  Color startingColor;

  void Start()
  {
    startingColor = currentText.color;

    if (FadeInOnStart)
    {
      StartCoroutine(FadeIn());
    }
  }

  public IEnumerator FadeIn()
  {
    Done = false;
    while(currentText.color.a < 1)
    {
      cachedAlpha += AlphaAmount;
      Color newAlpha = new Color(startingColor.r, startingColor.g, startingColor.b, cachedAlpha);
      currentText.color = newAlpha;
      yield return null;
    }
    Done = true;
  }
  
  public IEnumerator FadeOut()
  {
    Done = false;
    while(currentText.color.a > 0)
    {
      cachedAlpha -= AlphaAmount;
      Color newAlpha = new Color(startingColor.r, startingColor.g, startingColor.b, cachedAlpha);
      currentText.color = newAlpha;
      yield return null;
    }
    Done = true;
  }
}
