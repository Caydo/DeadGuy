using UnityEngine;
using System.Collections;

public class RandomAI : MonoBehaviour {
    public Actor actor;
    public Animator animator;

    void Awake() {
        DoSomethingRandom();
    }

    public void DoSomethingRandom() {
        int activateIndex = Random.Range(0, transform.childCount);

        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i == activateIndex);
        }
    }
}
