using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tile : MonoBehaviour
{

    [SerializeField] Tower towerPrefab;
    [SerializeField] bool isPlaceable;

    public bool IsPlaceable { get {return isPlaceable;}}

    GridManager gridManager;
    Vector2Int coordinates = new Vector2Int();

    void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
    }

    void Start() 
    {
        if(gridManager != null)
        {
            coordinates = gridManager.GetCoordinateFromPosition(transform.position);

            if(!isPlaceable)
            {
                gridManager.BlockNode(coordinates);
            }
        }
    }

    void OnMouseDown() 
    {   
        //Oppure molto semplicemente usiamo il metodo OnMouseDown
        //GetKeyDown quando si clicca una singola volta
        //if(Input.GetMouseButtonDown(0))
        if(isPlaceable)
        {   
            //d
            bool isPlaced = towerPrefab.CreateTower(towerPrefab, transform.position);
            //Instantiate(catapult, transform.position, Quaternion.identity);
            isPlaceable = !isPlaced;
        }
          
        
        
    }
}
