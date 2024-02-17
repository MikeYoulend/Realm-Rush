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
        //lo richiamiamo anche qui cosi quando premiamo play non crasha 
        DisplayCoordinates();
    }

    void Update()
    {
        //Se non abbiamo schiacciato su Play
        if(!Application.isPlaying) 
        {
            DisplayCoordinates();
            UpdateObjectName();
        }
    }

    void DisplayCoordinates()
    {
        //Cannot implicitly convert type 'float' to 'int'.
        //per risolvere questo problema usiamo Mathf.RoundToInt
        //si usa parent cosi il GameObject figlio prenderà sempre la posizione del padre
        //UnityEditor.EditorSnapSettings.move.x cioò significa....
        //Dividi la posizione per il movimento che hai impostasto su Unity in questo caso 10 
        //Quindi in posizione 10,0 diventerà 1,0
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x); 
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);
        label.text = coordinates.x + "," + coordinates.y;
    }

    void UpdateObjectName()
    {
        //Nella Hierarchy dai al nome le cordinate 
        transform.parent.name = coordinates.ToString();
    }
}
