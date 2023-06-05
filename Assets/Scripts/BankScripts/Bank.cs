using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;
    [SerializeField] int currentBalance;
    [SerializeField] TextMeshProUGUI goldText;

    public int CurrentBalance {  get { return currentBalance; } }
   
    void Awake()
    {
        currentBalance = startingBalance;
        UpdateGoldUI();

    }

    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount);
        UpdateGoldUI();
    }

    public void Withdraw(int amount )
    {
        currentBalance -= Mathf.Abs(amount);
        UpdateGoldUI();

        if (currentBalance <0)
        {
            ReloadScene();
        }
    }

    void UpdateGoldUI()
    {
        goldText.text = "Gold: " + currentBalance;
    }

    void ReloadScene()
    {
        Scene currentscene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentscene.buildIndex);
    }



    
   

}
