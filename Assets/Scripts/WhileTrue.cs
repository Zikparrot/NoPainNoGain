using UnityEngine;
using MyGame.Skills;
using MyGame.Characters;

[CreateAssetMenu(menuName = "Skills/WhileTrue")]
public class WhileTrue : PassiveTrait
{public override void OnSkillUsed(Character user, Skill skillUsed, Character target){
        user.budget += 1;

        Debug.Log($"> while(true) — +1 Budget (Current: {user.budget})");
    }
}