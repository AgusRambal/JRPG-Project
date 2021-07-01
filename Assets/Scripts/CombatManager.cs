using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CombatStatus
{ 
    WAITING_FOR_FIGHTER, 
    FIGHTER_ACTION, 
    CHECK_FOR_VICTORY, 
    NEXT_TURN
}


public class CombatManager : MonoBehaviour
{
    public HeroesAndSlayers[] characters;
    private int characterindex;

    private bool isCombatActive;

    private CombatStatus combatStatus;

    private Skill currentCharacterSkill;

    private void Start()
    {
        LogPanel.Write("Battle initiated");

        foreach (var chtr in this.characters)
        {
            chtr.combatManager = this;
        }

        this.combatStatus = CombatStatus.NEXT_TURN;

        this.characterindex = -1;
        this.isCombatActive = true;
        StartCoroutine(this.CombatLoop());
    }

    IEnumerator CombatLoop()
    {
        while (this.isCombatActive) //CUANDO ESTO ESTE EN 0 PUEDO CAMBIAR DE ESCENA!!
        {
            switch (this.combatStatus)
            {
                case CombatStatus.WAITING_FOR_FIGHTER:
                    yield return null;
                    break;

                case CombatStatus.FIGHTER_ACTION:
                    LogPanel.Write($"{this.characters[this.characterindex].idName} uses {currentCharacterSkill.skillName}.");
                    yield return null;
                    currentCharacterSkill.Run();

                    yield return new WaitForSeconds(1f);
                    this.combatStatus = CombatStatus.CHECK_FOR_VICTORY;

                    currentCharacterSkill = null;
                    break;

                case CombatStatus.CHECK_FOR_VICTORY:
                    foreach (var chtr in this.characters)
                    {
                        if (chtr.isAlive == false)
                        {
                            this.isCombatActive = false;

                            LogPanel.Write("Victory");
                        }
                        else
                        {
                            this.combatStatus = CombatStatus.NEXT_TURN;
                        }
                    }
                    yield return null;
                    break;

                case CombatStatus.NEXT_TURN:
                    yield return new WaitForSeconds(1f);

                    this.characterindex = (this.characterindex + 1) % this.characters.Length;

                    var currentTurn = this.characters[this.characterindex];

                    LogPanel.Write($"{currentTurn.idName} has the turn");
                    currentTurn.InitTurn();

                    this.combatStatus = CombatStatus.WAITING_FOR_FIGHTER;

                    break;
            }
        }
    }

    public HeroesAndSlayers GetOpposingFighter()
    {
        if (this.characterindex == 0)
        {
            return this.characters[1];
        }
        else
        {
            return this.characters[0];
        }
    }

    public void OnCharacterSkill(Skill skill)
    {
        this.currentCharacterSkill = skill;
        this.combatStatus = CombatStatus.FIGHTER_ACTION;
    }

}