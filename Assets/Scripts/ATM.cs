using UnityEngine;
using System.Collections.Generic;
using MyGame.Skills;
using MyGame.Characters;

public class ATM : Character
{
    [SerializeField] private Skill taskKill;
    [SerializeField] private PassiveTrait whileTrue;
    [SerializeField] private Skill encrypt;
    [SerializeField] private Skill collateralMode;

    void Awake()
    {
        characterName = "ATM";
        health = 100;

        skills = new List<Skill>
        {
            taskKill,
            encrypt,
            collateralMode
        };
            passives = new List<PassiveTrait>
        {
            whileTrue
        };
        
    }
}