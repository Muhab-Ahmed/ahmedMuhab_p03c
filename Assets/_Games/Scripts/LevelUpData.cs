using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Runtime.CompilerServices;


public class LevelUpData : MonoBehaviour
{


    [Header("Level Up/Exp Interface")]
    //we'll need access to the player's current level
    [SerializeField]
    private int _currentLevel;

    //we'll need acces to the player's current exp
    [SerializeField]
    private float _currentExp;

    //we'll need access to the player's max experience
    [SerializeField]
    private float _maxExp;


    //We'll need acess to the the player's level text
    [SerializeField] TextMeshProUGUI levelText;


    //W'll need access to the player's exp text bar
    [SerializeField] TextMeshProUGUI experienceText;

    //We'll need access to the player's fill bar to adjust
    [SerializeField] Image experienceFill;

    //We'll need to know by how much to increment for exp
    [SerializeField] int expIncrement;


    [Header("Stats Interface")]

    //We'll need to know the base values for each stats
    [SerializeField]
    private int _hp;
    [SerializeField]
    private int _attack;
    [SerializeField]
    private int _defense;
    [SerializeField]
    private int _speed;
    [SerializeField]
    private int _magic;

    //We'll need access to the text to change the values of the stats
    [SerializeField]
    private TextMeshProUGUI _hpText, _attackText,
        _defenseText, _speedText, _magicText;


    //We'll need to know by how much each stats will increase
    //per level up
    [SerializeField]
    private int _hpUpgrade, _attackUpgrade,
        _defenseUpgrade, _speedUpgrade, _magicUpgrade;
    

    private void Start()
    {
        UpdateInterface();
    }


    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            AddExperience(expIncrement);
        }
    }

    //The purpose of this function is to update the current exp
    //To check if the player is qualified to level up
    //To update the user interface based on the character's current
    //status update
    public void AddExperience(int amount)
    {
        //add amount to current exp
        _currentExp += amount;

        //Call function to check if the player can level up
        CheckForLevelUp();

        //Call function to change the display for the player
        UpdateInterface();
    }

    void CheckForLevelUp()
    {
        //check if the current exp is greater than the current exp goal
        if (_currentExp >= _maxExp)
        {

            //call function to level up the player
            LevelUp();

        }

    }

    //function's purpose is to update 
    void LevelUp()
    {
        //level player up
        _currentLevel++;

        //reset current exp and carry over any leftover
        _currentExp = _currentExp - _maxExp;

        //call function to update max expGoal
        UpdateMaxExp();

        //call function to update stats
        UpdateStats();
    }

    public void UpdateMaxExp()
    {
        //update maxExp goal
        _maxExp = _maxExp + 100;

        //call function to update user display
        UpdateInterface();
    }

    public void UpdateStats()
    {
        _hp = _hp + _hpUpgrade;
        _attack = _attack + _attackUpgrade;
        _defense = _defense + _defenseUpgrade;
        _speed = _speed + _speedUpgrade;
        _magic = _magic + _magicUpgrade;

        //call function to update user interface
        UpdateInterface();
    }

    void UpdateInterface()
    {
        //update display of player's current level and experience
        levelText.text = _currentLevel.ToString();
        experienceText.text = _currentExp + " exp/ " + _maxExp + " exp";
        experienceFill.fillAmount = _currentExp/_maxExp;

        //update display of player's stats
        _hpText.text = _hp.ToString();
        _attackText.text = _attack.ToString();
        _defenseText.text = _defense.ToString();
        _speedText.text = _speed.ToString();
        _magicText.text = _magic.ToString();

    }
}
