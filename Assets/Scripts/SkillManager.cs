using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using MyGame.Skills;
using MyGame.Characters;
public class SkillManager : MonoBehaviour{
    [SerializeField] private GameObject skillButtonPrefab;
    [SerializeField] private Transform skillMenuContainer;
    public static SkillManager Instance;

    public GameObject skillMenuUI;
    public List<Skill> availableSkills;
    void Awake(){
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void OpenSkillMenu(bool isPlayer, Character character){
        skillMenuUI.SetActive(true);
        Debug.Log("Skill menu opened for " + (isPlayer ? "Player" : "Opponent"));

        foreach (Transform child in skillMenuContainer.transform){
            Destroy(child.gameObject);
        }

        foreach (Skill skill in character.skills){
            GameObject buttonObj = Instantiate(skillButtonPrefab, skillMenuContainer.transform);
            Button button = buttonObj.GetComponent<Button>();
            Text nameText = buttonObj.GetComponentInChildren<Text>();
            Image iconImage = buttonObj.GetComponentInChildren<Image>();

            nameText.text = skill.skillName;
            iconImage.sprite = skill.icon;

            button.onClick.AddListener(() =>{
                skill.Activate(character, GetTarget(character));
                skillMenuUI.SetActive(false);
            });
        }
    }

    private Character GetTarget(Character user){
        foreach (Character c in FindObjectsOfType<Character>()){
            if (c != user && c.isPlayerControlled != user.isPlayerControlled){
                return c;
            }
        }

        Debug.LogWarning("No target found.");
        return null;
    }

    public void UnlockSkill(string skillName, int cost, bool isPlayer){
        bool success = GameManager.Instance.budgetManager.SpendBudget(isPlayer, cost);
        if (success){
            Debug.Log($"Skill '{skillName}' unlocked for ${cost}");
        }else{
            Debug.Log("Not enough money dawg.");
        }
    }

    public void UseSkill(string skillName, Character user, Character target){
        Skill skill = availableSkills.Find(s => s.skillName == skillName);
        if (skill != null){
            skill.Activate(user, target);
        }
    }
}