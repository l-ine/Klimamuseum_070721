using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderEventListener : MonoBehaviour
{
    private bool afforestation;
    private bool pricing;

    void Start()
    {
        //SliderEventSystem.aSimulatorSliderEvent(//hier alle möglichkeiten von float percentage, MouseClickRobot.PROXY_TYPE type);
        SliderEventSystem.aSimulatorSliderEvent += this.processSliderEvent;
    }

    void Update()
    {
        if (this.afforestation)
        {
            // in mouseclickrobot:
            //setPercentageExternal(perc, MouseClickRobot.AFFORESTATION);
            
        }
        if (this.pricing)
        {
            // in mouseclickrobot:
            //setPercentageExternal(perc, MouseClickRobot.PRICING);
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
