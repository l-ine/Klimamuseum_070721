using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyCollision : MonoBehaviour
{
    public GameObject player;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform != this.player.transform)
        {
            EventSystemBase.aCollisionEvent("price");
        }
    }
}
