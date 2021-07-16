using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventListenerPricing : MonoBehaviour
{
    public MouseClickRobot mouseClick;

    public GameObject coal;
    public GameObject machineDisplay;

    public GameObject[] coins;
    public float percentage;

    private bool pricing = false;

    private bool counterLength = false;

    private int counter = -1;

    void Start()
    {
        EventSystemBase.aCollisionEvent += this.processCollisionEvent;
        //this.mouseClick.proxyType = MouseClickRobot.PROXY_TYPE.PRICING;
    }

    void Update()
    {
        if (this.pricing && counter < coins.Length)
        {
            /*if (this.counter == (money.Length - 1))
            {
                this.counterLength = true;
            }*/
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
        Debug.Log("counter0: " + counter);
        // geld verschwindet mit berührung/collision
        coins[this.counter].transform.position = this.machineDisplay.transform.position;//new Vector3(-0.5f, 0f, 10.98f);
        Debug.Log("counter1: " + counter);

        if (this.counter == (coins.Length - 1))
        {
            Debug.Log("counter2: " + counter);
            // kohle ausgeben
            coal.AddComponent<Rigidbody>();
            //Rigidbody rb = coal.AddComponent<Rigidbody>() as RigidBody;
            //transform.position = new Vector3(-0.4f, 0.5f, 10.6f);
        }
    }
}
