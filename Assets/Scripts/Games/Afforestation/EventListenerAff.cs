using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZenFulcrum.EmbeddedBrowser;

public class EventListenerAff : MonoBehaviour
{
    public MouseClickRobot mouseClick;
    
    public Trees[] tree;

    public float percentage;

    private bool growing = false;
    
    private int counter = -1;

    private Vector3[] scale;

    void Start()
    {
        EventSystemBase.aCollisionEvent += this.processCollisionEvent;
    }

    void Update()
    {
        if (this.growing && counter < tree.Length)
        {
            // loop is because we want that it is possible for all trees to grow at the same time
            for (int i = 0; i <= counter; i++)
            {
                // call method grow in Trees -> current tree is growing until its scale is (0.2, 0.2, 0.2) 
                tree[i].grow(scale[i]);
            }
        }
    }

    void processCollisionEvent(string type)
    {
        if (type == "grow")
        {
            // type is "grow" -> set growing true, so the grow function is called in the Update-method
            this.growing = true;
            counter++;

            // save the scale of every tree in the array scale
            // because the scales are continuously changing, when the trees are growing
            this.scale = new Vector3[] { tree[0].transform.localScale, 
                                         tree[1].transform.localScale, 
                                         tree[2].transform.localScale };

            // percentage (so how much the slider is changing) is calculated: 
            this.percentage = (counter + 1) / 3f;
            // method setPercentageExternal() in script ExtractingImage is called
            // -> slider of proxyType changes to the certain percentage
            mouseClick.setPercentageExternal(percentage, mouseClick.proxyType);
        }
    }
}