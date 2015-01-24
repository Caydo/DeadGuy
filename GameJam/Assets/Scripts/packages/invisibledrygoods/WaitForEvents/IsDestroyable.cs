using UnityEngine;
using System.Collections;
using Require;

public class IsDestroyable : MonoBehaviour
{
    public WaitFor waitForDestroyed = new WaitFor();

    public void Destroy()
    {
        waitForDestroyed.Happened();
        Destroy(gameObject);
    }
}
