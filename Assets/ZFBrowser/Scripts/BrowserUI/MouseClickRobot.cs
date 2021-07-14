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

    private void Update()
    {
        

    /* if (Input.GetKeyUp(KeyCode.RightArrow))
     {
         if (this.MaxX != -1.0f && this.MinX != -1.0f)
         {
             this.transform.localPosition += new Vector3((this.MaxX - this.MinX) / 100.0f, 0f, 0f);
             if (this.transform.localPosition.x > this.MaxX)
             {
                 this.transform.localPosition = new Vector3(this.MaxX, this.transform.localPosition.y, this.transform.localPosition.z);
             }
         }
     }

     if (Input.GetKeyUp(KeyCode.LeftArrow))
     {
         if (this.MaxX != -1.0f && this.MinX != -1.0f)
         {
             this.transform.localPosition += new Vector3(-(this.MaxX - this.MinX) / 100.0f, 0f, 0f);
             if (this.transform.localPosition.x < this.MinX)
             {
                 this.transform.localPosition = new Vector3(this.MinX, this.transform.localPosition.y, this.transform.localPosition.z);
             }
         }
     }*/

    /* if (Input.GetKeyUp(KeyCode.UpArrow))
     {
         this.setPercentage(Random.value);
     }*/
}

    public void setPercentage(float percentage)
    {
        Debug.Log(percentage);
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

        this.BrowserProxy.relevantProxyType = MouseClickRobot.PROXY_TYPE.INITIAL;
        this.BrowserProxy.relevantProxyType = this.proxyType;
        if (this.proxyType == PROXY_TYPE.AFFORESTATION)
        {
            StartCoroutine(extractingImage.fetchGraph(1, 0));
        }
        if (this.proxyType == PROXY_TYPE.PRICING)
        {
            StartCoroutine(extractingImage.fetchGraph(0, 1));
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
