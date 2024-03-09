using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{   
    //Dictionary è una struttura dati in C# che associa una chiave univoca a un valore. 
    //È simile a un dizionario reale in cui una parola (la chiave) è associata al suo significato (il valore).
    //Vector2Int è un modo per rappresentare posizioni o vettori in uno spazio bidimensionale utilizzando solo numeri interi
    [SerializeField] Vector2Int gridSize;
    Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int, Node>();

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
                Debug.Log(grid[coordinates].coordinates + " = " + grid[coordinates].isWalkable);
            }
        }
    }
}
