using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baum : MonoBehaviour
{
    public float passedTime = 0f;
    
    public void grow(Vector3 scale)
    {
        //this.passedTime = 0f;
        this.passedTime += Time.deltaTime;
        if (this.passedTime < 10.0f)
        {
            this.transform.localScale = Vector3.Lerp(new Vector3(0.2f, 0.2f, 0.2f),
                                                          scale,
                                                          1 / this.passedTime);
        }
    }
}
