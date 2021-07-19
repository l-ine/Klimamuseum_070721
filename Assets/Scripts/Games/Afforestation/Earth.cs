using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth : MonoBehaviour
{
    public Trees tree;
    
    // sets the tree to the position of the earth
    public void transformPosition()
    {
        this.tree.transform.position = this.transform.position;
    }
}
