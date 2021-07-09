using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClickController : MonoBehaviour
{
    public Soil[] soil;
    public GameObject lastHit;
    
    public int counter = 0;

    // Update is called once per frame
    void Update()
    {
        if (counter < soil.Length)
        {
            if (Input.GetMouseButtonUp(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    lastHit = hit.transform.gameObject;
                    if (hit.transform == soil[counter].transform)
                    {
                        soil[counter].positionswechsel();
                        counter++;
                        
                    }
                }
            }
        }
    }
}
