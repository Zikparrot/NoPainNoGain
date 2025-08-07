using UnityEngine;
using MyGame.Skills;
using MyGame.Characters;
public class PlunderPunch : Skill{
    [SerializeField] private int damage = 3;
    [SerializeField] private float stealChance = 0.5f;

    public override void Activate(Character user, Character target){
        // damage code
        target.TakeDamage(damage);
        Debug.Log($"{user.name} hits {target.name} with Plunder Punch for {damage} damage!");

        // rng thing that has a chance to steal opponent budget
        if (Random.value < stealChance && target.budget > 0){
            target.budget -= 1;
            user.budget += 1;
            Debug.Log($"{user.name} steals 1 Budget from {target.name}!");
        }else{
            Debug.Log($"{user.name} failed to steal Budget.");
        }
    }
}