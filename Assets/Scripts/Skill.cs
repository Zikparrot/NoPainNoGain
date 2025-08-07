using UnityEngine;
using MyGame.Characters;
namespace MyGame.Skills{
    [System.Serializable]
    public abstract class Skill : ScriptableObject{
        public string skillName;
         public Sprite icon;
        public string description;
        public int cost;
        public int damage;
        public bool isDebuff;


        
        public abstract void Activate(Character user, Character target);
        protected void ApplyDebuff(Character target){
            Debug.Log($"{target.characterName} is debuffed by {skillName}");
            target.ApplyBudgetChange(-2);
        }
    }
}