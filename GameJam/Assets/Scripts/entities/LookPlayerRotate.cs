using UnityEngine;
using System.Collections;

public class LookPlayerRotate : MonoBehaviour
{
	GameObject player;

	float spriteOffset = 30f;
	void Awake()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	// Update is called once per frame
	void LateUpdate (){
		transform.rotation =// Quaternion.Lerp(
			//transform.rotation,
			Quaternion.LookRotation(transform.position, player.transform.position);
		transform.eulerAngles = new Vector3 (0, 0, transform.eulerAngles.z+spriteOffset);
	}
}
