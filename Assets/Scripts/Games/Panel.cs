using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{
    public ExtractingImage extractingImage;
    public int index;

    void Start()
    {
        // displays the corresponding graph, even before the task was started
        StartCoroutine(extractingImage.fetchGraph(index));
    }
}
