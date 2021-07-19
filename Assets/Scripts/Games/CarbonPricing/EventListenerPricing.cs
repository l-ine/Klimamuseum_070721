using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventListenerPricing : MonoBehaviour
{
    public MouseClickRobot mouseClick;

    public GameObject coal;
    
    public GameObject machineDisplay;
    public Texture[] textures;
   
    public GameObject[] coins;
   
    public float percentage;

    private bool pricing = false;

    private int counter = -1;

    void Start()
    {
        EventSystemBase.aCollisionEvent += this.processCollisionEvent;
        
    }

    void Update()
    {
        if (this.pricing && counter < coins.Length)
        {
            disappear(coins);
        }
    }

    void processCollisionEvent(string type)
    {
        if (type == "price")
        {
            this.pricing = true;
            counter++;
            percentage = (counter + 1) / 6f;
            mouseClick.setPercentageExternal(percentage, mouseClick.proxyType);
        }
    }

    void disappear(GameObject[] coins)
    {
        // coins disappear in the vending machine
        coins[this.counter].transform.position = this.machineDisplay.transform.position;

        // display changes
        machineDisplay.GetComponent<MeshRenderer>().material.mainTexture = textures[this.counter + 1];

        // coal comes out of the vending machine
        if (this.counter == (coins.Length - 1))
        {
            coal.AddComponent<Rigidbody>();
        }
    }
}
