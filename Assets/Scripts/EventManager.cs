using UnityEngine;

public static class EventManager{
    public static void TriggerRandomEvent(){
        int roll = Random.Range(0, 100);
        if (roll < 20){
            Debug.Log("Mark Zuckerburg jumpscare. Everyone loses $20.");
            GameManager.Instance.budgetManager.AddBudget(true, -20);
            GameManager.Instance.budgetManager.AddBudget(false, -20);
        }
        else if (roll < 40){
            Debug.Log("Uh oh, here comes Inflation. All actions cost +10 next turn.");
            GameManager.Instance.actionCostModifier = 10;
        }else{
            Debug.Log("Time for a raise. Everyone gains $15.");
            GameManager.Instance.budgetManager.AddBudget(true, 15);
            GameManager.Instance.budgetManager.AddBudget(false, 15);
        }
    }
}

