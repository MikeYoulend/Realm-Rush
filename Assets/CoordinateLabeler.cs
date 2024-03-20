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
    [SerializeField] Color exploredColor = Color.yellow;
    [SerializeField] Color pathColor = new Color(1f, 0.5f, 0f);

    TextMeshPro label;
    //Qui con seconda parte stiamo inizializzando coordinate con i valori predefiniti quindi Vector2( x = 0 & y = 0)
    Vector2Int coordinates = new Vector2Int(); 
    GridManager gridManager;

    void Awake() //Awake  è letteralmente la prima cosa che viene fatta
    {
        gridManager = FindObjectOfType<GridManager>();
        label = GetComponent<TextMeshPro>();
        //di default lo teniamo disabilitato
        label.enabled = false;
        GetComponentInParent<Tile>();
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
            label.enabled = true;
        }

        SetLabelColor();
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

    void SetLabelColor()
    {   
        if(gridManager == null) {return;}

        Node node = gridManager.GetNode(coordinates); 

        //per fixxare l'errore
        if(node == null) { return; }

        if(!node.isWalkable)
        {
            label.color = blockedColor;
        } 
        else if(node.isPath)
        {
            label.color = pathColor;
        } 
        else if(node.isExplored)
        {
            label.color = exploredColor;
        } else
        {
            label.color = defaultColor;
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
        if(gridManager == null) { return; }
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / gridManager.UnityGridSize); 
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / gridManager.UnityGridSize);
        label.text = coordinates.x + "," + coordinates.y;
    }

    void UpdateObjectName()
    {
        //Nella Hierarchy dai al nome le cordinate 
        transform.parent.name = coordinates.ToString();
    }
}
