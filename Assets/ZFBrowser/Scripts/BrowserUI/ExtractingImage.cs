using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZenFulcrum.EmbeddedBrowser;

public class ExtractingImage : MonoBehaviour
{
    public Browser browser;

    public Browser refbrowser;

    public PointerUIBase BrowserProxy;

   /* public void Start()
    {
        StartCoroutine(initialClick);
    }

    public IEnumerator initialClick()
    {
        browser.relevantProxyType = MouseClickRobot.PROXY_TYPE.INITIAL;
    }*/

    public IEnumerator fetchGraph(int index)
    {
        var promise = this.browser.EvalJS("document.getElementsByClassName(\"chartjs-render-monitor\")[" + index + "].toDataURL(\"img/png\")");
        yield return promise.ToWaitFor();

        this.refbrowser.EvalJS("document.getElementById(\"image-container\").src = '" + promise.Value + "';");
        this.refbrowser.EvalJS("document.getElementById(\"image-container\").width = '" + 500 + "';");
        this.refbrowser.EvalJS("document.getElementById(\"image-container\").height = '" + 500 + "';");
    }
}

//Ahhh und zusätzlich haben wir in dem Extract Image Skript eine Coroutine gestartet die einer Methode aufruft, die zu Beginn einmal den INITAL Proxy Clickt, damit man zu dem Richtigen Browserfenster kommt, indem man die Slider verstellen kann