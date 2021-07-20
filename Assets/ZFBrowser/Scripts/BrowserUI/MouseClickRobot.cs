using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZenFulcrum.EmbeddedBrowser;

public class MouseClickRobot : MonoBehaviour
{
    public enum PROXY_TYPE
    {
        NONE,
        INITIAL,
        AFFORESTATION,
        PRICING
    }

    public PROXY_TYPE proxyType;

    public float MinX = -1.0f;

    public float MaxX = -1.0f;

    private float initialX;

    public PointerUIBase BrowserProxy;
    
    public ExtractingImage extractingImage;

    void Start()
    {
        this.initialX = this.transform.localPosition.x;
    }

    public void setPercentage(float percentage)
    {
        // change the proxy's position on the webplugin
        if (this.MaxX != -1.0f && this.MinX != -1.0f)
        {
            this.transform.localPosition = new Vector3(this.MinX + (this.MaxX - this.MinX) * percentage, this.transform.localPosition.y, this.transform.localPosition.z);
            if (this.transform.localPosition.x < this.MinX)
            {
                this.transform.localPosition = new Vector3(this.MinX, this.transform.localPosition.y, this.transform.localPosition.z);
            }
            if (this.transform.localPosition.x > this.MaxX)
            {
                this.transform.localPosition = new Vector3(this.MaxX, this.transform.localPosition.y, this.transform.localPosition.z);
            }
        }

        // simulate the click with this instance of PointerUIBase
        BrowserProxy.relevantProxyType = this.proxyType;

        // fetch graph in the respective panel using the ExtractingImage script
        if (this.proxyType == PROXY_TYPE.AFFORESTATION)
        {
            // Afforestation panel shows right graph on the website: Greenhouse Gas Net Emissions
            StartCoroutine(extractingImage.fetchGraph(1));
        }
        if (this.proxyType == PROXY_TYPE.PRICING)
        {
            // Carbon Pricing panel shows left graph on the website: Global Sources of Primary Energy
            StartCoroutine(extractingImage.fetchGraph(0));
        }
    }

    public void setPercentageExternal(float percentage, MouseClickRobot.PROXY_TYPE type)
    {
        if (this.proxyType == type)
        {
            // the incoming proxy is the same as the one in the script MouseClickRobot script here
            // -> call the setPercentage function with the incoming percentage of already planted trees or paid coins
            setPercentage(percentage);
        }
    }
}
