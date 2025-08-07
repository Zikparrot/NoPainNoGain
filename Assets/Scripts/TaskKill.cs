using UnityEngine;
using MyGame.Skills;
using MyGame.Characters;

[CreateAssetMenu(menuName = "Skills/TaskKill")]
public class TaskKill : Skill{
    public override void Activate(Character user, Character target){
        const int requiredBudget = 10;

        if (user.budget < requiredBudget){
            Debug.Log($"> TASK: KILL FAILED — INSUFFICIENT FUNDS");
            return;
        }

        user.budget -= requiredBudget;

        Debug.Log($"> TASK: KILL");
        Debug.Log($"> TARGET IDENTIFIED: {target.name}");
        Debug.Log($"> EXECUTING...");

        // utter obliteration lmfao
        target.Die();

        Debug.Log($"> EXECUTION COMPLETE — {target.name} REMOVED FROM LEDGER");
    }
}