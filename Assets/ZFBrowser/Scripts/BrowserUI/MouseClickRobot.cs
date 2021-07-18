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
        COAL,
        OIL,
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

        //BrowserProxy.relevantProxyType = MouseClickRobot.PROXY_TYPE.INITIAL;
        BrowserProxy.relevantProxyType = this.proxyType;
        if (this.proxyType == PROXY_TYPE.AFFORESTATION)
        {
            StartCoroutine(extractingImage.fetchGraph(1));
        }
        if (this.proxyType == PROXY_TYPE.PRICING)
        {
            StartCoroutine(extractingImage.fetchGraph(0));
        }
       

    }

    public void setPercentageExternal(float percentage, MouseClickRobot.PROXY_TYPE type)
    {
        if (this.proxyType == type)
        {
            setPercentage(percentage);
        }
    }
}
