using UnityEngine;

public class BudgetManager : MonoBehaviour{
    public int playerBudget = 100;
    public int opponentBudget = 100;
    public void AddBudget(bool isPlayer, int amount){
        if (isPlayer){
            playerBudget += amount;
            Debug.Log($"Player has gained ${amount}. New budget: {playerBudget}");
        }else{
            opponentBudget += amount;
            Debug.Log($"Opponent has gained ${amount}. New budget: {opponentBudget}");
        }
    }
    public bool SpendBudget(bool isPlayer, int amount){
        Debug.Log($"SpendBudget called. isPlayer: {isPlayer}, amount: {amount}");

        if (isPlayer){
            Debug.Log($"Player budget before: {playerBudget}");
            if (playerBudget >= amount){
                playerBudget -= amount;
                Debug.Log($"Player budget after: {playerBudget}");
                return true;
            }else{
                Debug.Log("You cant afford this bro.");
            }
        }
        else{
            Debug.Log($"Opponent budget before: {opponentBudget}");
            if (opponentBudget >= amount){
                opponentBudget -= amount;
                Debug.Log($"Opponent budget after: {opponentBudget}");
                return true;
            }else{
                Debug.Log("It doesnt have enough money. Womp Womp.");
            }
        }

        return false;
    }
}