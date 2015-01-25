using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUDElement : MonoBehaviour
{
  public Actor PlayerActor;
  public Player Player;
  public int ElementNumber;
  public Sprite EnabledSprite;
  public Sprite DisabledSprite;
  public Image CurrentSprite;
  public bool IsHeart;
  bool activeElement;

	// Update is called once per frame
	void Update ()
  {
    if(IsHeart)
    {
      activeElement = (PlayerActor.HP >= ElementNumber);
    }
    else
    {
      activeElement = (Player.HorcruxCount >= ElementNumber);
    }

    CurrentSprite.sprite = (activeElement) ? EnabledSprite : DisabledSprite;
	}
}