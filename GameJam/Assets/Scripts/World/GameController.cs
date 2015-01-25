using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

  List<LevelController> levels;
  public int CurrentLevel;

  public 

	// Use this for initialization
	void Start () {
    levels = new List<LevelController>(GetComponentsInChildren<LevelController>());
	}
	
	// Update is called once per frame
	void Update () {
	  
	}
}
