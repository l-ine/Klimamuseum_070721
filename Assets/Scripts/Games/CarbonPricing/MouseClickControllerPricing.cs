using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClickControllerPricing : MonoBehaviour
{
    public GameObject lastHit;
    public GameObject machineDisplay;
    public GameObject[] coins;

    public int counter = 0;

    void Update()
    {
        if (this.counter < coins.Length)
        {
            if (Input.GetMouseButtonUp(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    lastHit = hit.transform.gameObject;

                    // only if the mouse click hits the machine's display,
                    // a coin should change its position to the hit position (and disappears inside the machine)
                    if (hit.transform == machineDisplay.transform)
                    {
                        this.coins[counter].transform.position = hit.transform.position;
                        counter++;
                    }
                }
            }
        }
    }
}
