using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class CoordinateLabeler : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockedColor = Color.gray;

    TextMeshPro label;
    //Qui con seconda parte stiamo inizializzando coordinate con i valori predefiniti quindi Vector2( x = 0 & y = 0)
    Vector2Int coordinates = new Vector2Int(); 
    Waypoint waypoint;

    void Awake() //Awake  è letteralmente la prima cosa che viene fatta
    {
        label = GetComponent<TextMeshPro>();
        //di default lo teniamo disabilitato
        label.enabled = false;
        waypoint = GetComponentInParent<Waypoint>();
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

        ColorCordinates();
        ToggleLabels();
    }

    void ToggleLabels()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            //settiamo label nello stato opposto a quello attualmente attivo
            label.enabled = !label.IsActive();
        }
    }

    void ColorCordinates()
    {
        if(waypoint.IsPlaceable)
        {
            label.color = defaultColor;
        } 
        else 
        {
            label.color = blockedColor;
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
