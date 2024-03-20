using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{   
    //Dictionary è una struttura dati in C# che associa una chiave univoca a un valore. 
    //È simile a un dizionario reale in cui una parola (la chiave) è associata al suo significato (il valore).
    //Vector2Int è un modo per rappresentare posizioni o vettori in uno spazio bidimensionale utilizzando solo numeri interi
    [SerializeField] Vector2Int gridSize;
    [Tooltip("World Grid Size - Should match UnityEditor snap settings.")]
    [SerializeField] int unityGridSize = 10;
    public int UnityGridSize { get {return unityGridSize; } }
    Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int, Node>();
    public Dictionary<Vector2Int, Node> Grid { get { return grid;} }


    void Awake()
    {
        CreateGrid();
    }   

    //ritorniamo Node dal Dictionary
    public Node GetNode(Vector2Int coordinates)
    {
        //controlla se nel dizionario grid c'è una voce associata a quelle cordinate
        //se esiste ristituisce il nodo corrispondente
        //se non esiste restituisce null quindi nessun nodo
        if(grid.ContainsKey(coordinates))
        {
            return grid[coordinates];
        }
        
        return null;
    }

    public void BlockNode(Vector2Int coordinates)
    {
        if(grid.ContainsKey(coordinates))
        {
            grid[coordinates].isWalkable = false;
        }
    }

    public Vector2Int GetCoordinateFromPosition(Vector3 position)
    {
        Vector2Int coordinates = new Vector2Int();
        coordinates.x = Mathf.RoundToInt(position.x / unityGridSize); 
        coordinates.y = Mathf.RoundToInt(position.z / unityGridSize);

        return coordinates;
    }

    public Vector3 GetPositionFromCoordinates(Vector2Int coordinates)
    {
        Vector3 position = new Vector3();
        position.x = coordinates.x * unityGridSize;
        position.z = coordinates.y * unityGridSize;

        return position;
    }

    void CreateGrid()
    {   
        //SPIEGAZIONE
        //Creiamo la griglia sull'asse x di 1 e poi in alto(Y) di quanto è la gridsize
        for(int x = 0; x < gridSize.x; x++)
        {
            for(int y = 0; y < gridSize.y; y++)
            {   
                //Crea un nuovo oggetto Vector2Int che rappresenta le coordinate correnti nella griglia.
                Vector2Int coordinates = new Vector2Int(x,y);
                //stiamo dicendo a Unity di aggiungere una riga a questa tabella.
                //La prima colonna di questa riga sarà il numero di coordinate che stiamo considerando
                //la seconda colonna sarà il tipo di "nodo" che vogliamo creare.
                grid.Add(coordinates, new Node(coordinates, true));
            }
        }
    }
}
