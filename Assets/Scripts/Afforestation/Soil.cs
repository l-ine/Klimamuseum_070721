using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soil : MonoBehaviour
{
    public Baum tree;
    
    public void positionswechsel()
    {
        this.tree.transform.position = this.transform.position;
    }
}
