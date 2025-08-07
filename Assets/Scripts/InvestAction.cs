using UnityEngine;

public class InvestAction : MonoBehaviour{
    public int cost = 7;
    public bool isPlayer = true;

    public void Execute(){
        bool success = GameManager.Instance.ExecuteAction(isPlayer, cost);
        if (success){
            int returnAmount = Random.Range(0, 10); // lets go gambling!
            GameManager.Instance.budgetManager.AddBudget(isPlayer, returnAmount);
            GameManager.Instance.uiManager.UpdateBudgetDisplay(
                GameManager.Instance.budgetManager.playerBudget,
                GameManager.Instance.budgetManager.opponentBudget
            );
            Debug.Log($"Invest returned ${returnAmount}");
        }
        else{
            Debug.Log("Aw dangit.");
        }
    }
}