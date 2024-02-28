using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int goldReward = 25;
    [SerializeField] int goldPenalty = 25;

    Bank bank;
    
    void Start()
    {
        bank = FindObjectOfType<Bank>();
    }

    public void RewardGold()
    {   
        if(bank == null) {return;}
        //diamo allo script Bank il metodo Deposit e gli passiamo goldReward
        bank.Deposit(goldReward);
    }
    public void StealGold()
    {   
        if(bank == null) {return;}
        //diamo allo script Bank il metodo Deposit e gli passiamo goldReward
        bank.Withdraw(goldPenalty);
    }
}
