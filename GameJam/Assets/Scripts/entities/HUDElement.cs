using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUDElement : MonoBehaviour
{
  public int ElementNumber;
  public Sprite EnabledSprite;
  public Sprite DisabledSprite;
  public Image CurrentSprite;
  public bool IsHeart;

  Player Player;
  Actor PlayerActor;
  bool activeElement;

  void Start()
  {
    GameObject playerGO = GameObject.FindGameObjectWithTag("Player");
    Player = playerGO.GetComponent<Player>();
    PlayerActor = playerGO.GetComponent<Actor>();
  }

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