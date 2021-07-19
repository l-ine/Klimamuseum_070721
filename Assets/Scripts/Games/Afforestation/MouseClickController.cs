using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClickController : MonoBehaviour
{
    public Earth[] earths;
    public GameObject lastHit;
    
    public int counter = 0;

    void Update()
    {
        if (counter < earths.Length)
        {
            if (Input.GetMouseButtonUp(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    lastHit = hit.transform.gameObject;

                    // only when the mouse click hit one of the earths,
                    // a tree should change his position to one of the earth's position
                    // (with the method transformPosition() in the script "Earth")
                    if (hit.transform == earths[counter].transform)
                    {
                        earths[counter].transformPosition();
                        counter++;
                        
                    }
                }
            }
        }
    }
}
