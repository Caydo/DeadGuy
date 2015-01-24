using UnityEngine;
using System.Collections.Generic;
using Require;

public class Receives2DCollisionEvents : MonoBehaviour
{
    public float radius;
    public LayerMask mask;

    public WaitFor<Transform> waitForCollision = new WaitFor<Transform>();

    void FixedUpdate()
    {
        foreach (Collider2D other in Physics2D.OverlapCircleAll(transform.position, radius, mask))
        {
            waitForCollision.Happened(other.transform);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
