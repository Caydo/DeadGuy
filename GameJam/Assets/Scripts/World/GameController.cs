using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

  public List<LevelController> levels;
  public int CurrentLevel = 0;
  bool changeLevel = false;
	
	// Update is called once per frame
	void Update () 
  {
	  if(levels[CurrentLevel].LevelComplete && levels[CurrentLevel].Exiting)
    {
      levels[CurrentLevel].gameObject.SetActive(false);
      CurrentLevel = levels[CurrentLevel].ExitTo;
      levels[CurrentLevel].gameObject.SetActive(true);

      Transform transform = levels[CurrentLevel].transform;
      Vector3 pos = new Vector3(transform.position.x, transform.position.y, -10);
      Camera.main.camera.transform.position = pos;
    }
	}

  public void WinGame()
  {
    // WIN HERE!!! ZOMG YOU WON GO YOU, A WINNER IS YOU!!
  }
}
