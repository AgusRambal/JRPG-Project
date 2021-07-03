using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : HeroesAndSlayers
{
    public GameObject winText, winButton, goPanel;
    public bool isAlive
    {
        get => stats.health > 0;
    }

    private void Awake()
    {
        this.stats = new Stats(50, 50, 40, 30, 60);
        winButton.SetActive(false);
        winText.SetActive(false);
    }

    public void Update()
    {
        if (isAlive == false)
        {
            Invoke("EnemyDie", 0.75f);
        }
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

    protected void EnemyDie()
    {
        this.statusPanel.gameObject.SetActive(false);
        this.gameObject.SetActive(false);
        this.winText.SetActive(true);
        this.winButton.SetActive(true);
        this.goPanel.SetActive(true);
    }
}

