using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZenFulcrum.EmbeddedBrowser;

public class ExtractingImage : MonoBehaviour
{
    public Browser browser;

    public Browser refbrowser;

    public PointerUIBase BrowserProxy;

    public IEnumerator initialClick()
    {
        BrowserProxy.relevantProxyType = MouseClickRobot.PROXY_TYPE.INITIAL;
        yield return null;
    }

    public IEnumerator fetchGraph(int index)
    {
        var promise = this.browser.EvalJS("document.getElementsByClassName(\"chartjs-render-monitor\")[" + index + "].toDataURL(\"img/png\")");
        yield return promise.ToWaitFor();

        this.refbrowser.EvalJS("document.getElementById(\"image-container\").src = '" + promise.Value + "';");
        this.refbrowser.EvalJS("document.getElementById(\"image-container\").width = '" + 500 + "';");
        this.refbrowser.EvalJS("document.getElementById(\"image-container\").height = '" + 500 + "';");
        
        StartCoroutine(initialClick());
    }
}