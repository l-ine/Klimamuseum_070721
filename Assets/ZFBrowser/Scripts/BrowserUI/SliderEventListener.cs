using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderEventListener : MonoBehaviour
{
    private bool afforestation;
    private bool pricing;

    // Start is called before the first frame update
    void Start()
    {
        //SliderEventSystem.aSimulatorSliderEvent(//hier alle möglichkeiten von float percentage, MouseClickRobot.PROXY_TYPE type);
        SliderEventSystem.aSimulatorSliderEvent += this.processSliderEvent;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(EventListener.percentage);
        if (this.afforestation)
        {
           
        }
        if (this.pricing)
        {
            //...
        }
    }

    void processSliderEvent(float percentage, MouseClickRobot.PROXY_TYPE type)
    {
        if (type == MouseClickRobot.PROXY_TYPE.AFFORESTATION)
        {
            this.afforestation = true;            
        }
        if (type == MouseClickRobot.PROXY_TYPE.PRICING)
        {
            this.pricing = true;
        }
    }
}
