using UnityEngine;
using MyGame.Skills;
using MyGame.Characters;
public class FlintlockBlast : Skill{
    [SerializeField] private int trueDamage = 8;

    public override void Activate(Character user, Character target){
        target.TakeTrueDamage(trueDamage);
        Debug.Log($"{user.name} fires their flintlock at {target.name}, dealing {trueDamage} true damage.");
    }
}