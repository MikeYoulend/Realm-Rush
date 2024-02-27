using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    //diamo un numero alla pool di nemici che vogliamo
    [SerializeField] int poolSize = 5;
    [SerializeField] float spawnTimer = 1f;
    
    //definiamo l'array della pool
    GameObject[] pool;

    void Awake() 
    {
        PopulatePool();    
    }

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    void PopulatePool()
    {   
        //pool avrà massimo 5 nemici
        pool = new GameObject[poolSize];

        for(int i = 0;  i < pool.Length; i++)
        {
            pool[i] = Instantiate(enemyPrefab, transform);
            pool[i].SetActive(false);
        }
    }

    void enableObjectInPool()
    {
        for( int i = 0; i < pool.Length; i++)
        {
            if(pool[i].activeInHierarchy == false)
            {
                pool[i].SetActive(true);
                return;
            }
        }
    }

    IEnumerator SpawnEnemy()
    {
        while(true)
        {
            enableObjectInPool();
            yield return new WaitForSeconds(spawnTimer);
        }
    }


}
