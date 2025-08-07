using UnityEngine;
using MyGame.Skills;
using MyGame.Characters;

[CreateAssetMenu(menuName = "Skills/Encrypt")]
public class Encrypt : Skill{
    [SerializeField] private BudgetShield budgetShieldEffect;

    public override void Activate(Character user, Character target){
        target.ApplyStatusEffect(budgetShieldEffect);
        Debug.Log($"> ENCRYPT() — BUDGET ENCRYPTED. PROTECTION ACTIVE.");
    }
}