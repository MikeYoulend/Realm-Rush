using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

//NO MonoBehaviour = non è un componente Unity
//è un semplice classe che contiene dati o logica
public class Node
{
   public Vector2Int coordinates;
   public bool isWalkable;
   public bool isExplored;
   public bool isPath;
   public Node connectedTo;


    //costruttore
   public Node(Vector2Int coordinates, bool isWalkable)
   {    
        //this prende il coordinates che fa parte del constructor
        this.coordinates = coordinates;
        this.isWalkable = isWalkable;
   }
}
