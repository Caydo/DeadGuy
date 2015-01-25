using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
  public int HorcruxCount;
  InteractableObject interactionObject;
  public string DialogText;

  void Update()
  {
    if(Input.GetButtonUp("Fire3"))
    {
      Interact();
    }
  }

  void OnTriggerEnter(Collider objectCollidedWith)
  {
    interactionObject = objectCollidedWith.GetComponent<InteractableObject>();
  }

  void OnTriggerExit(Collider objectCollidedWith)
  {
    interactionObject = null;
  }

  void Interact()
  {
    if(interactionObject != null)
    {
      DialogText = interactionObject.GetPhrase();
      interactionObject.Used = true;
    }
  }
}