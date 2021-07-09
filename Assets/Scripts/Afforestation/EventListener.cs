using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventListener : MonoBehaviour
{
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
            percentage = counter/3; // ---> diesen in SliderEventlistener weiterleiten
            this.scale = new Vector3[] { tree[0].transform.localScale, tree[1].transform.localScale, tree[2].transform.localScale };
        }
    }
}

