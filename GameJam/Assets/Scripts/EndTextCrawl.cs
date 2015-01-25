using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EndTextCrawl : MonoBehaviour
{
  public Text TextToCrawl;
  public bool CrawlOnStart;
  public string TextToAdd;
  public float TimeBetweenNextCrawl;
  public bool FullySetText = false;
  public Button ButtonToProgress;
  public float DelayBeforeCrawl;

  void Awake()
  {
    TextToAdd = "You defeated the Lich that put a memory spell on you when you first arrived. Through exploration and your wits you pieced the events together."
      + "\n\nClearly, the Lich enslaved the demons that attacked you. They seemed to be trying to stop you from reviving the Lich."
     + "\n\nBaseball, magic, and the power of investigation has won this time. Though perhaps another evil is just around the corner.\n\nClick To Continue";
  }

  void Start()
  {
    TextToCrawl.text = string.Empty;
    StartCoroutine(addTextThenWait());
  }

  IEnumerator addTextThenWait()
  {
    yield return new WaitForSeconds(DelayBeforeCrawl);
    if (CrawlOnStart)
    {
      for (int i = 0; i < TextToAdd.Length; i++)
      {
        if (!FullySetText)
        {
          TextToCrawl.text += TextToAdd[i];
          yield return new WaitForSeconds(TimeBetweenNextCrawl);
        }
        else
        {
          yield break;
        }
      }
    }
    progress();
  }

  void Update()
  {
    if (Input.GetButtonUp("Fire1") || Input.GetButtonUp("Fire2"))
    {
      if (!FullySetText)
      {
        progress();
      }
    }
  }

  void progress()
  {
    FullySetText = true;
    StopCoroutine(addTextThenWait());
    TextToCrawl.text = TextToAdd;
    ButtonToProgress.interactable = true;
  }
}