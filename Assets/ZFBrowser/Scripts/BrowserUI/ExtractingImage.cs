using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZenFulcrum.EmbeddedBrowser;

public class ExtractingImage : MonoBehaviour
{
    public Browser browser;

    public Browser[] refbrowsers;

    private bool fetchingAff = false;

    private bool fetchingPric = false;


    void Start()
    {
        //EventSystemBase.aCollisionEvent += this.processCollisionEvent;
    }

    //void processCollisionEvent(string type)
    //{
       /* if (type == "grow")
        {
            this.fetchingAff = true;
        }

        if (type == "automat")
        {
            this.fetchingPric = true;
        }*/
        
    //}

        void Update()
    {
        /*if (this.fetchingAff)
        {
            StartCoroutine(this.fetchGraph(1, 0));
        }

        if (this.fetchingPric)
        {
            StartCoroutine(this.fetchGraph(0, 1));
        }*/
    }

    public IEnumerator fetchGraph(int index, int browserCounter)
    {
        var promise = this.browser.EvalJS("document.getElementsByClassName(\"chartjs-render-monitor\")[" + index + "].toDataURL(\"img/png\")");
        yield return promise.ToWaitFor();
        // Debug.Log("promised value: " + promise.Value);
        this.refbrowsers[browserCounter].EvalJS("document.getElementById(\"image-container\").src = '" + promise.Value + "';");
        this.refbrowsers[browserCounter].EvalJS("document.getElementById(\"image-container\").width = '" + 500 + "';");
        this.refbrowsers[browserCounter].EvalJS("document.getElementById(\"image-container\").height = '" + 500 + "';");
    }
}
