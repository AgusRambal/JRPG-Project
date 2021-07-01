using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : HeroesAndSlayers
{
    private void Awake()
    {
        this.stats = new Stats(50, 50, 40, 30, 60);
    }
    public override void InitTurn()
    {
        StartCoroutine(this.IA());
    }

    IEnumerator IA()
    {
        yield return new WaitForSeconds(1f);

        Skill skill = this.skills[Random.Range(0, this.skills.Length)];

        skill.SetEmitterAndReceiver(this, this.combatManager.GetOpposingFighter());

        this.combatManager.OnCharacterSkill(skill);
    }

}

