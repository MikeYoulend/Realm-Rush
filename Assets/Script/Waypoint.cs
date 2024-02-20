using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    void OnMouseOver() 
    {   
        //GetKeyDown quando si clicca una singola volta
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log(transform.name);
        }
        
    }
}
