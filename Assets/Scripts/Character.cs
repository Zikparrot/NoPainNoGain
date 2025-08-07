using UnityEngine;
using System.Collections.Generic;
using MyGame.Skills;

namespace MyGame.Characters{
    public class Character : MonoBehaviour{
        public string characterName;
        public string flavorText;
        public List<StatusEffect> activeStatusEffects = new List<StatusEffect>();
        public List<PassiveTrait> passives = new List<PassiveTrait>();
        public bool isPlayerControlled;
        public int health = 100;
        public int budget = 10;

        //skills stuff
        public List<Skill> skills;
        public Skill ultimateSkill;
        public PassiveTrait passiveTrait;
    
        public void ApplyStatusEffect(StatusEffect effect){
            activeStatusEffects.Add(effect);
            effect.OnApply(this);
            Debug.Log($"{characterName} gained status: {effect.effectName}");
        }

        public void RemoveStatusEffect(StatusEffect effect){
            if (activeStatusEffects.Contains(effect)){
                activeStatusEffects.Remove(effect);
                effect.OnRemove(this);
                Debug.Log($"{characterName} lost status: {effect.effectName}");
            }
        }

        public void ExecuteSkill(int skillIndex, Character target){
            if (skillIndex < 0 || skillIndex >= skills.Count) return;

            Skill skill = skills[skillIndex];
            if (budget >= skill.cost){
                budget -= skill.cost;
                skill.Activate(this, target);
                passiveTrait?.OnSkillUsed(this, skill, target);
            }else{
                Debug.Log($"{characterName} can't afford {skill.skillName}.");
            }
        }

        public virtual void TakeDamage(int amount){
            health -= amount;
            Debug.Log($"{characterName} took {amount} damage. Remaining health: {health}");

            if (health <= 0){
                Die();
            }
        }

        public void TakeTrueDamage(int amount){
            health -= amount;
            Debug.Log($"{characterName} takes {amount} true damage.");

            if (health <= 0){
                Die();
            }
        }

        public void ApplyBudgetChange(int amount){
            foreach (var effect in activeStatusEffects){
                effect.OnBudgetChange(this, amount);
                return;
            }

            budget += amount;
            Debug.Log($"{characterName}'s budget changed by {amount}. New budget: {budget}");


        }

        public virtual void OnTurnStart(){
        }

        public void Die(){
            Debug.Log($"{characterName} has been defeated. Lol.");
        }
        
        public void EndTurn(){
        foreach (var effect in new List<StatusEffect>(activeStatusEffects)){
            effect.OnTurnEnd(this);
        }
    }

    }
}