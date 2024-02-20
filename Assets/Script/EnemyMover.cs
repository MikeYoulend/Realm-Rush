using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] [Range(0f, 5f)] float speed = 1f;
   
    // Start is called before the first frame update
    void Start()
    {  
        
        StartCoroutine(FollowPath());
        
        //InvokeRepeating("NomeDelMetodo", tempoDiRitardo, Intervallo)
        //InvokeRepeating("PrintWaypointName", 0, 1f);
        
    }


  //IEnumerator in C# è un interfaccia utilizzata in Unity per definire coroutine, che sono funzioni che possono essere eseguite in modo asincrono. Le coroutine consentono di eseguire azioni come attese o operazioni asincrone senza bloccare il flusso principale del programma.
    IEnumerator FollowPath()
    {
        foreach(Waypoint waypoint in path)
        {   
            Vector3 startPosition = transform.position;
            Vector3 endPosition = waypoint.transform.position;
            //Aggiunto 1 su asse y senò sarebbe nel terreno
            endPosition.y += 1f; 
            float traverlPercent = 0f;

            transform.LookAt(endPosition);

            while(traverlPercent < 1f){
            traverlPercent += Time.deltaTime * speed;
            //lerp si spiega da solo
            //valore negativo a travelPercent rompe tutto
            transform.position = Vector3.Lerp(startPosition, endPosition, traverlPercent);
            yield return new WaitForEndOfFrame(); //letteralmente
            }
            
            //Arrivati a questo punto gli diciamo ritorna qui fra un secondo
            //yield return new WaitForSeconds(waitTime);
        }
    }
}