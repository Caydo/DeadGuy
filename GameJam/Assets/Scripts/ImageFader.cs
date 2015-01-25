using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ImageFader : MonoBehaviour
{
  public bool FadeInOnStart = false;
 
  float AlphaIncrementAmount = 0.03f;
  public Image currentSprite;
  float cachedAlpha = 0;
  Color startingColor;

  void Start()
  {
    startingColor = currentSprite.color;

    if(FadeInOnStart)
    {
      StartCoroutine(FadeIn());
    }
  }

  public IEnumerator FadeIn()
  {
    while(currentSprite.color.a < 1)
    {
      cachedAlpha += AlphaIncrementAmount;
      Color newAlpha = new Color(startingColor.r, startingColor.g, startingColor.b, cachedAlpha);
      currentSprite.color = newAlpha;
      yield return null;
    }
  }
  
  public IEnumerator FadeOut()
  {
    while(currentSprite.color.a > 0)
    {
      cachedAlpha -= AlphaIncrementAmount;
      Color newAlpha = new Color(startingColor.r, startingColor.g, startingColor.b, cachedAlpha);
      currentSprite.color = newAlpha;
      yield return null;
    }
	}
}
