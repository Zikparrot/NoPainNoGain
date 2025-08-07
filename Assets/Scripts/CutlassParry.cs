using UnityEngine;
using MyGame.Skills;
using MyGame.Characters;
public class CutlassParry : Skill{
    public override void Activate(Character user, Character target){
        PirateCharacter pirate = user as PirateCharacter;
        if (pirate == null || !pirate.CanUseParry){
            Debug.Log($"{user.name} cannot use Cutlass Parry this turn, matey!");
            return;
        }

        pirate.IsParrying = true;
        pirate.CanUseParry = false;
        Debug.Log($"{user.name} activates Cutlass Parry and is immune to damage this turn! Yarr lmfao.");
    }
}