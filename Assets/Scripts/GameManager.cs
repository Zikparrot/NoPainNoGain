using UnityEngine;
using MyGame.Characters;
public class GameManager : MonoBehaviour{
    public static GameManager Instance;
    public Character playerCharacter;
    public Character opponentCharacter;
    public TurnManager turnManager;
    public BudgetManager budgetManager;
    public UIManager uiManager;
    public int actionCostModifier = 0; // for the inflation thing
    void Awake(){
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start(){
        uiManager.UpdateTurnDisplay(turnManager.isPlayerTurn);
        uiManager.UpdateBudgetDisplay(budgetManager.playerBudget, budgetManager.opponentBudget);
    }

    public bool ExecuteAction(bool isPlayer, int cost){
        int finalCost = cost + actionCostModifier;
        bool success = budgetManager.SpendBudget(isPlayer, finalCost);

        if (success){
            Debug.Log($"Action executed for ${finalCost}");
            uiManager.UpdateBudgetDisplay(budgetManager.playerBudget, budgetManager.opponentBudget);
            turnManager.EndTurn();
        }else{
            Debug.Log("Not enough budget.");
        }

        return success;
    }
}