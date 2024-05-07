using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Runtime.CompilerServices;


public class LevelUpData : MonoBehaviour
{

    //we'll need access to the player's current level
    [SerializeField]
    private int _currentLevel;

    //we'll need acces to the player's current exp
    [SerializeField]
    private float _currentExp;

    //we'll need access to the player's max experience
    [SerializeField]
    private float _maxExp;

    [Header("Interface")]
    //We'll need acess to the the player's level text
    [SerializeField] TextMeshProUGUI levelText;

    //W'll need access to the player's exp text bar
    [SerializeField] TextMeshProUGUI experienceText;

    //We'll need access to the player's fill bar to adjust
    [SerializeField] Image experienceFill;

    //We'll need to know by how much to increment for exp
    [SerializeField] int expIncrement;

    

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
    }

    public void UpdateMaxExp()
    {
        //update maxExp goal
        _maxExp = _maxExp + 100;

        //call function to update user display
        UpdateInterface();
    }

    void UpdateInterface()
    {

        levelText.text = _currentLevel.ToString();
        experienceText.text = _currentExp + " exp/ " + _maxExp + " exp";

        float expFillAmount = _currentExp/_maxExp;
        Debug.Log(_currentExp / _maxExp);
        experienceFill.fillAmount = _currentExp/_maxExp;
    }
}
