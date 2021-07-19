using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trees : MonoBehaviour
{
    public float passedTime = 0f;
    
    // trees begin to grow to a scale of (0.2, 0.2, 0.2)
    public void grow(Vector3 scale)
    {
        this.passedTime += Time.deltaTime;

        // lerp function is limited by passedTime
        if (this.passedTime < 10.0f)
        {
            this.transform.localScale = Vector3.Lerp(new Vector3(0.2f, 0.2f, 0.2f),
                                                          scale,
                                                          1 / this.passedTime);
        }
    }
}
