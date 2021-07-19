using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowCollision : MonoBehaviour
{
    public Trees tree;

    private void OnCollisionEnter(Collision collision)
    {
        // only if it is a collision with a tree, the collision should be called "grow"
        if (collision.transform == this.tree.transform)
        {
            EventSystemBase.aCollisionEvent("grow");
        }
    }
}
