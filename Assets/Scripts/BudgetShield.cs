using UnityEngine;
using MyGame.Skills;
using MyGame.Characters;
[CreateAssetMenu(menuName = "StatusEffects/BudgetShield")]
public class BudgetShield : StatusEffect{
    public int remainingTurns = 1;

    public override void OnBudgetChange(Character target, int amount){
        if (amount < 0){
            Debug.Log($"> BudgetShield active — Budget loss blocked");
            return;
        }

        target.budget += amount;
    }

    public override void OnTurnEnd(Character target){
        remainingTurns--;
        if (remainingTurns <= 0){
            target.RemoveStatusEffect(this);
            Debug.Log($"> BudgetShield expired");
        }
    }
}
