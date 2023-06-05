using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Bank bank;

    [SerializeField] int goldPenalty = 25;
    [SerializeField] int goldReward = 25;
   
    void Start()
    {
        bank = FindObjectOfType<Bank>();
    }

    public void RewardGold()
    {
        if (bank == null)
        {
            return;
        }

        bank.Deposit(goldReward);
    }

    public void StealGold()
    {
        if (bank == null)
        {
            return;
        }

        bank.Withdraw(goldPenalty);
    }

    
    void Update()
    {
        
    }
}
