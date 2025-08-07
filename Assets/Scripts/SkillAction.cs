using UnityEngine;
using UnityEngine.UI;
using MyGame.Skills;
using MyGame.Characters;

public class SkillAction : MonoBehaviour{
    public bool isPlayer = true;
    public GameObject skillButtonPrefab;
    public Transform skillMenuPanel;
    [SerializeField] private Transform skillMenuContainer;

    public void Execute(){
        OpenSkillMenu(isPlayer);
        Debug.Log("Skills pay the bills. Literally.");
    }

    public void OpenSkillMenu(bool isPlayer){
        foreach (Transform child in skillMenuPanel){
            Destroy(child.gameObject);
        }

        Character active = isPlayer ? GameManager.Instance.playerCharacter : GameManager.Instance.opponentCharacter;
        Character target = isPlayer ? GameManager.Instance.opponentCharacter : GameManager.Instance.playerCharacter;

        foreach (Skill skill in active.skills){
            GameObject buttonObj = Instantiate(skillButtonPrefab, skillMenuPanel);
            SkillButton button = buttonObj.GetComponent<SkillButton>();
            button.SetSkill(skill);

            Button uiButton = buttonObj.GetComponent<Button>();
            uiButton.onClick.AddListener(() => UseSkill(skill, active, target));
        }

        skillMenuPanel.gameObject.SetActive(true);
    }

    private void UseSkill(Skill skill, Character user, Character target){
        Debug.Log($"{user.characterName} used {skill.skillName} on {target.characterName}!");
        skill.Activate(user, target);
    }
}