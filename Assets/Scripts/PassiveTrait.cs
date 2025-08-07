using UnityEngine;
using MyGame.Skills;
using MyGame.Characters;
[System.Serializable]
public abstract class PassiveTrait : ScriptableObject{
    public string traitName;
    public string description;
    public virtual void OnApply(Character target){ 
    }
    public virtual void OnRemove(Character target){ 
    }
    public virtual void OnTurnEnd(Character target){ 
    }
    public virtual void OnBudgetChange(Character spender, int amount){ 
    }
    public abstract void OnSkillUsed(Character user, Skill skill, Character target);
}