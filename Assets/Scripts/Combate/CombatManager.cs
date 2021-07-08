using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CombatStatus
{ 
    WAITING_FOR_FIGHTER, 
    FIGHTER_ACTION, 
    CHECK_ACTION_MESSAGES,
    CHECK_FOR_VICTORY, 
    NEXT_TURN
}


public class CombatManager : MonoBehaviour
{
    public HeroesAndSlayers[] characters;
    private int characterindex;

    public Enemy enemy;

    public PlayerHeroe hero;

    private bool isCombatActive;

    private CombatStatus combatStatus;

    private Skill currentCharacterSkill;

    private HealthModSkill damage;

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

    IEnumerator CombatLoop() //Arranca el loop de la batalla
    {
        while (this.isCombatActive)
        {
            switch (this.combatStatus)
            {
                case CombatStatus.WAITING_FOR_FIGHTER:
                    yield return null;
                    break;

                case CombatStatus.FIGHTER_ACTION: //Si es el turno de alguien, se espera a que ataque, y pone en panel que habilidad utilizo
                    LogPanel.Write($"{this.characters[this.characterindex].idName} uses {currentCharacterSkill.skillName}.");
                    yield return null;
                    currentCharacterSkill.Run();

                    yield return new WaitForSeconds(1f);
                    this.combatStatus = CombatStatus.CHECK_ACTION_MESSAGES;

                    break;

                case CombatStatus.CHECK_ACTION_MESSAGES: //Pone en panel los mensajes situacionales

                    string nextMessage = this.currentCharacterSkill.GetNextMessage();

                    if (nextMessage != null)
                    {
                        LogPanel.Write(nextMessage);
                        yield return new WaitForSeconds(2f);
                    }
                    else
                    {
                        this.currentCharacterSkill = null;
                        this.combatStatus = CombatStatus.CHECK_FOR_VICTORY;
                        yield return null;
                    }

                    break; 

                case CombatStatus.CHECK_FOR_VICTORY: //Se fija si esta muerto el palyer o el enemigo y sino, pasa de turno

                    if (hero.isAlive == false)
                    {
                        this.isCombatActive = false;
                        //ACAAAA CAMBIAR DE ESCENA
                        LogPanel.Write("You Loose");
                    }
                    else if (enemy.isAlive == false)
                    {
                        LogPanel.Write("You Win");
                    }
                    else
                    {
                        this.combatStatus = CombatStatus.NEXT_TURN;
                    }
                    yield return null;
                    break;
                    
                case CombatStatus.NEXT_TURN: //Dice qquien tiene el turno y inicializa el initTurn para arrancar el mismo
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