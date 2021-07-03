using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeroe : HeroesAndSlayers
{
    [Header("UI")]
    public PlayerSkillPanel skillPanel;

    public GameObject gameOverText, restartButton, goPanel;

    public bool isAlive
    {
        get => stats.health > 0;
    }

    private void Awake()
    {
        this.stats = new Stats(21, 60, 50, 45, 20);

        gameOverText.SetActive(false);
        restartButton.SetActive(false);
        goPanel.SetActive(false);
    }

    public void Update()
    {
        if (isAlive == false)
        {
            Invoke("Die", 0.75f);
        }
    }

    public override void InitTurn()
    {
        this.skillPanel.Show();

        for (int i = 0 ; i < this.skills.Length ; i++)
        {
            this.skillPanel.ConfigureButtons(i, this.skills[i].skillName);
        }
    }

    public void ExecuteSkill(int index)
    {
        this.skillPanel.Hide();

        Skill skill = this.skills[index];

        skill.SetEmitterAndReceiver(this, this.combatManager.GetOpposingFighter());

        this.combatManager.OnCharacterSkill(skill);
    }

    protected void Die()
    {
        this.statusPanel.gameObject.SetActive(false);
        this.gameObject.SetActive(false);
        this.gameOverText.SetActive(true);
        this.restartButton.SetActive(true);
        this.goPanel.SetActive(true);
    }

}
