using UnityEngine;
using System.Collections;
using Assets.Scripts.powerups;
using System;
using System.Collections.Generic;

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

  public string[] Phrases;
  public string ShortPhrase;
  public string Name;
  [NonSerialized]
  public int TimesSeen = 0;
  public bool Passable = false;
  public bool forced = false;
  public List<Powerup> PowerUp;

  // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
