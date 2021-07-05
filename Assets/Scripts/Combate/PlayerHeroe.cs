using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHeroe : HeroesAndSlayers
{
    [Header("UI")]
    public PlayerSkillPanel skillPanel;

    public GameObject gameOverText, restartButton, goPanel;

    private Pociones powerUp;

    private Pociones2 powerUp2;

    public GameObject foto1, foto2;

    public bool isAlive
    {
        get => stats.health > 0; //El player esta vivo si tiene vida mayor a 0
    }

    private void Awake()
    {
        powerUp = FindObjectOfType<Pociones>(); //accede a los scripts para llamar a las variables de los mismos
        powerUp2 = FindObjectOfType<Pociones2>();

            if (powerUp.havePowerUp == 0 && powerUp2.havePowerUp2 == 0) //Condiciones para acceder a la batalla con un powerup o el otro
            {
                stats = new Stats(21, 60, 50, 45, 20);
            }

            else if (powerUp.havePowerUp == 0 && powerUp2.havePowerUp2 == 2)
            {
                stats = new Stats(22, 60, 50, 45, 20);
                foto2.SetActive(true);
            }

            else if (powerUp.havePowerUp == 1 && powerUp2.havePowerUp2 == 0)
            {
                stats = new Stats(21, 70, 50, 45, 20);
                foto1.SetActive(true);
            }

            gameOverText.SetActive(false);
            restartButton.SetActive(false);
            goPanel.SetActive(false);
    }

    public void Update()
    {
        if (isAlive == false)
        {
            Invoke("Die", 0.75f); //si muero invoco la funcion die despues de 0.75s
        }
    }

    public override void InitTurn() //En el comienzo del turno muestro el panel y muestro las skills con sus nombres
    {
        this.skillPanel.Show();

        for (int i = 0 ; i < this.skills.Length ; i++)
        {
            this.skillPanel.ConfigureButtons(i, this.skills[i].skillName);
        }
    }

    public void ExecuteSkill(int index) //Ejecuto la funcion de la habilidad que presione y oculto el panel
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
