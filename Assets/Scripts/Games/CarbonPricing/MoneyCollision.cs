using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyCollision : MonoBehaviour
{
    public GameObject player;

    private void OnCollisionEnter(Collision collision)
    {
        // if it is not the player that collides, the collision should be called "price"
        if (collision.transform != this.player.transform)
        {
            EventSystemBase.aCollisionEvent("price");
        }
    }
}
