using UnityEngine;
using MyGame.Skills;
using MyGame.Characters;
public class DabbleDoubloons : Skill{
    public override void Activate(Character user, Character target){
        PirateCharacter pirate = user as PirateCharacter;
        if (pirate == null) return;

        if (pirate.HasBuriedGold){
            Debug.Log($"{user.name} already buried gold.");
            return;
        }

        if (user.budget < 2){
            Debug.Log($"{user.name} doesn't have enough budget to bury.");
            return;
        }

        user.budget -= 2;
        pirate.BuriedBudget = 2;
        pirate.BuriedTurnsRemaining = 2;
        pirate.HasBuriedGold = true;

        Debug.Log($"{user.name} buries 2 budget. Come back later.");
    }
}