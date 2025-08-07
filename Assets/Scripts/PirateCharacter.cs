using UnityEngine;
using MyGame.Characters;
using MyGame.Skills;
public class PirateCharacter : Character{
    public bool IsParrying = false;
    public bool CanUseParry = true;
    public int BuriedBudget = 0;
    public int BuriedTurnsRemaining = 0;
    public bool HasBuriedGold = false;
    public override void OnTurnStart(){
        base.OnTurnStart();

        if (HasBuriedGold){
            BuriedTurnsRemaining--;

            if (BuriedTurnsRemaining <= 0){
                int returnedBudget = BuriedBudget + 1;
                budget += returnedBudget;
                Debug.Log($"{characterName} digs up his booty 🤨 and gains {returnedBudget} budget.");

                BuriedBudget = 0;
                HasBuriedGold = false;
            }
        }
            IsParrying = false;
            CanUseParry = true;


    }

    public override void TakeDamage(int amount){
        if (IsParrying){
            Debug.Log($"{characterName} parried the attack.");
            return;
        }

        base.TakeDamage(amount);
    }
}