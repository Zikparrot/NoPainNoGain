using UnityEngine;
using MyGame.Characters;
using MyGame.Skills;

[CreateAssetMenu(menuName = "Traits/CollateralMode")]
public class CollateralMode : PassiveTrait{
    [SerializeField] private BudgetShield shieldEffect;
    [SerializeField, Range(0f, 1f)] private float taxRate = 0.1f;

    private bool isActive = false;
    private Character atm;

    public override void OnApply(Character target){
        atm = target;
    }

    public override void OnTurnEnd(Character target){
        if (!isActive && atm.budget <= 0){
            isActive = true;
            Debug.Log($"> PHASE_2: COLLATERAL_MODE() INITIATED");
        }

        if (isActive){
            atm.ApplyStatusEffect(shieldEffect);
            Debug.Log($"> COLLATERAL_MODE — BUDGET SHIELD APPLIED");
        }
    }

    public override void OnBudgetChange(Character spender, int amount){
        if (!isActive || spender == atm || amount >= 0) return;

        int taxAmount = Mathf.CeilToInt(Mathf.Abs(amount) * taxRate);
        atm.ApplyBudgetChange(taxAmount);

        Debug.Log($"> COLLATERAL_MODE — {spender.characterName} TAXED {taxAmount} FROM SPENDING");
    }

    public override void OnRemove(Character target){
        atm = null;
    }

    public override void OnSkillUsed(Character user, Skill skillUsed, Character target){
    }
}