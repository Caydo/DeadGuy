using UnityEngine;
using System.Collections;
using Assets.Scripts.powerups;
using System;
using System.Collections.Generic;

[RequireComponent(typeof(SphereCollider))]
public class InteractableObject : MonoBehaviour 
{
  /*
   * Phrases[]
   * Short Phrase
   * Name
   * TimesSeen
   * Passable
   * Forced
   * Powerup
   *
   * */
  [NonSerialized]
  public int TimesSeen = 0;
  [NonSerialized]
  public bool IsUsable = false;
  [NonSerialized]
  public bool Used = false;

  public string Name;
  public bool Passable = false;
  public bool Forced = false;
  public Powerup[] PowerUp;

  [SerializeField]
  string[] Phrases;
  [SerializeField]
  string ShortPhrase;

  Collider trigger;

  // Use this for initialization
	void Start () 
  {
    trigger = GetComponent<SphereCollider>();
	}
	
	// Update is called once per frame
	void Update () 
  {
	  
	}

  void OnTriggerEnter()
  {
    IsUsable = true;
  }

  void OnTriggerExit()
  {
    
    IsUsable = false;
  }

  public string GetPhrase()
  {
    string retVal = string.Empty;
    if (IsUsable)
    {
      ++TimesSeen;
      if (TimesSeen < Phrases.Length)
        retVal = Phrases[TimesSeen];
      else
        retVal = ShortPhrase;
    }
    return retVal;
  }
}
