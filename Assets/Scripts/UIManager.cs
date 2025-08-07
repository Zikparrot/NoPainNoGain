using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour{
    public TMP_Text turnText;
    public TMP_Text playerBudgetText;
    public TMP_Text opponentBudgetText;


    public void UpdateTurnDisplay(bool isPlayerTurn){
        turnText.text = isPlayerTurn ? "Your Turn" : "Opponent's Turn";
    }

    public void UpdateBudgetDisplay(int playerBudget, int opponentBudget){
        playerBudgetText.text = "$" + playerBudget.ToString();
        opponentBudgetText.text = "$" + opponentBudget.ToString();
    }

    public class ActionController : MonoBehaviour{
    public AttackAction attackAction;
    public SkillAction skillAction;
    public InvestAction investAction;

    public void OnAttackButton(){
        attackAction.Execute();
    }

    public void OnInvestButton(){
        investAction.Execute();
    }

    public void OnSkillButton(){
        skillAction.Execute();
    }
}
}