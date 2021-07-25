using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{
    public ExtractingImage extractingImage;
    public int index;

    void Start()
    {
        StartCoroutine(extractingImage.fetchGraph(index));
    }
}
