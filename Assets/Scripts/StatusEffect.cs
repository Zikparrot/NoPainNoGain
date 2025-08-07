using UnityEngine;
using MyGame.Characters;
public abstract class StatusEffect : ScriptableObject{
    public string effectName;
    public Sprite icon;

    // status applied
    public virtual void OnApply(Character target) { }

    // status dies
    public virtual void OnRemove(Character target) { }

    // when budget changes
    public virtual void OnBudgetChange(Character target, int amount) { }

    // on end of turbn
    public virtual void OnTurnEnd(Character target) { }
}