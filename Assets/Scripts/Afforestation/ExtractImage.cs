using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZenFulcrum.EmbeddedBrowser;

public class ExtractImage : MonoBehaviour
{
    public Browser browser;

    public Browser refbrowser;

    private bool fetching = false;

    void Start()
    {
        EventSystemBase.aCollisionEvent += this.processCollisionEvent;
    }

    void processCollisionEvent(string type)
    {
        if (type == "grow")
        {
            this.fetching = true;
        }
    }

        void Update()
    {
        if (this.fetching)
        {
            StartCoroutine(this.fetchGraph(1));
        }
    }

    private IEnumerator fetchGraph(int index)
    {
        var promise = this.browser.EvalJS("document.getElementsByClassName(\"chartjs-render-monitor\")[" + index + "].toDataURL(\"img/png\")");
        yield return promise.ToWaitFor();
        // Debug.Log("promised value: " + promise.Value);
        this.refbrowser.EvalJS("document.getElementById(\"image-container\").src = '" + promise.Value + "';");
        this.refbrowser.EvalJS("document.getElementById(\"image-container\").width = '" + 500 + "';");
        this.refbrowser.EvalJS("document.getElementById(\"image-container\").height = '" + 500 + "';");
    }
}
