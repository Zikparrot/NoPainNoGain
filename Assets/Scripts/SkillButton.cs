using UnityEngine;
using UnityEngine.UI;
using MyGame.Skills;
using MyGame.Characters;

public class SkillButton : MonoBehaviour{
    public Text skillNameText;
    public Button button;
    public void SetSkill(Skill skill){
        skillNameText.text = skill.skillName;
    }

    public Button onClick => button;
}