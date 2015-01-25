using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
  public int HorcruxCount;
  InteractableObject interactionObject;
  public Text DialogText;
  public float DialogDisplayTime = 3f;
  Actor actor;

  void Start()
  {
    actor = GetComponent<Actor>();
  }

  void Update()
  {
    if(Input.GetButtonUp("Fire3"))
    {
      Debug.Log("Fire3 hit");
      StartCoroutine(Interact());
    }
  }

  void OnTriggerEnter(Collider objectCollidedWith)
  {
    var collided = objectCollidedWith.GetComponent<InteractableObject>();
    if(collided)
      interactionObject = collided;
    
  }

  void OnTriggerExit(Collider objectCollidedWith)
  {
    interactionObject = null;
  }

  IEnumerator Interact()
  {
    if(interactionObject != null)
    {
      DialogText.text = interactionObject.Interact(actor);
      yield return new WaitForSeconds(DialogDisplayTime);
      DialogText.text = string.Empty;
    }
    yield break;
  }
}