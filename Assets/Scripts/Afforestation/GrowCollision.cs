using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowCollision : MonoBehaviour
{
    public Baum tree;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform == this.tree.transform)
        {
            EventSystemBase.aCollisionEvent("grow");
        }
    }
}
