using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


[ExecuteAlways]
public class CoordinateLabeler : MonoBehaviour
{
    TextMeshPro label;
    //Qui con seconda parte stiamo inizializzando coordinate con i valori predefiniti quindi Vector2( x = 0 & y = 0)
    Vector2Int coordinates = new Vector2Int(); 

    void Awake() //Awake  è letteralmente la prima cosa che viene fatta
    {
        label = GetComponent<TextMeshPro>();
    }

    void Update()
    {
        //Se non abbiamo schiacciato su Play
        if(!Application.isPlaying) 
        {
            DisplayCoordinates();
        }
    }

    void DisplayCoordinates()
    {
        //Cannot implicitly convert type 'float' to 'int'.
        //per risolvere questo problema usiamo Mathf.RoundToInt
        //si usa parent cosi il GameObject figlio prenderà sempre la posizione del padre
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x); 
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z);
        label.text = coordinates.x + "," + coordinates.y;
    }
}
