using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//è un attributo che assicura che il componente 
//specificato sia sempre presente sull'oggetto a cui è applicato lo script. 
//In questo caso, assicura che l'oggetto abbia sempre un componente Enemy allegato ad esso.
[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{      
    [SerializeField] int maxHitPoints = 5;
    [SerializeField] int difficultyRamp = 1;
    int currentHitPoints = 0;
    
    Enemy enemy;

    void OnEnable()
    {
        currentHitPoints = maxHitPoints;
    }
    void Start() 
    {
       enemy = GetComponent<Enemy>();
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        currentHitPoints--;
        if (currentHitPoints < 1)
        {
            gameObject.SetActive(false);
            //così aumentiamo la vita dei nemici
            maxHitPoints += difficultyRamp;
            enemy.RewardGold();
        }
    }
}
