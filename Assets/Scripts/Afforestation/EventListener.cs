using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZenFulcrum.EmbeddedBrowser;

public class EventListener : MonoBehaviour
{
    public MouseClickRobot mouseClick;
    
    
    public Baum[] tree;
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
            for (int i = 0; i <= counter; i++)
            {
                tree[i].grow(scale[i]);
            }
        }
    }

    void processCollisionEvent(string type)
    {
        if (type == "grow")
        {
            this.growing = true;
            counter++;
            this.scale = new Vector3[] { tree[0].transform.localScale, tree[1].transform.localScale, tree[2].transform.localScale };
            percentage = (counter + 1) / 3f;
            mouseClick.setPercentageExternal(percentage, mouseClick.proxyType);
        }
    }
}