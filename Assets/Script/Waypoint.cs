using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] bool isPlaceable;
    [SerializeField] GameObject catapult;

    void OnMouseDown() 
    {   
        //Oppure molto semplicemente usiamo il metodo OnMouseDown
        //GetKeyDown quando si clicca una singola volta
        //if(Input.GetMouseButtonDown(0))
        if(isPlaceable)
        {
            GameObject Tower = Instantiate(catapult, transform.position, Quaternion.identity);
            isPlaceable = false;
        }
          
        
        
    }
}
