using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSystemBase : MonoBehaviour
{
    // an event system for detecting collisions
    // (used for the games about afforestation and carbon pricing)
    public delegate void CollisionEvent(string type);
    public static CollisionEvent aCollisionEvent;
}