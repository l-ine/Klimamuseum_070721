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
            // call pay function
            pay(coins);
        }
    }

    void processCollisionEvent(string type)
    {
        if (type == "price")
        {
            // type is "price" -> set pricing true, so the pay function is called in the Update-method
            this.pricing = true;
            counter++;

            // percentage (so how much the slider is changing in the webplugin) is calculated: 
            percentage = (counter + 1) / 6f;
            // method setPercentageExternal() in script ExtractingImage is called
            // -> slider of proxyType changes to the certain percentage
            mouseClick.setPercentageExternal(percentage, mouseClick.proxyType);
        }
    }

    void pay(GameObject[] coins)
    {
        // coins disappear in the vending machine
        coins[this.counter].transform.position = this.machineDisplay.transform.position;

        // display of the machine changes and shows number of coins that are already paid
        machineDisplay.GetComponent<MeshRenderer>().material.mainTexture = textures[this.counter + 1];

        if (this.counter == (coins.Length - 1))
        {
            // all coins are paid -> coal piece comes out of the vending machine
            coal.AddComponent<Rigidbody>();
        }
    }
}
