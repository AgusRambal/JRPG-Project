using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : HeroesAndSlayers
{
    public GameObject winText, winButton, goPanel;
    public bool isAlive
    {
        get => stats.health > 0; //El enemigo esta vivo si tiene vida mayor a 0
    }

    private void Awake()
    {
        this.stats = new Stats(20, 50, 40, 30, 60); //Estadisticas del enemigo
        winButton.SetActive(false);
        winText.SetActive(false);
    }

    public void Update()
    {
        if (isAlive == false)
        {
            Invoke("EnemyDie", 0.75f); //En el update chequeo si el enemigo esta vivo, si no lo esta, invoco a la funcion de muerte despues de 0.75 segundos
        }
    }

    public override void InitTurn()
    {
        StartCoroutine(this.IA()); //Se aplica la courrtina en el inico dle turno
    }

    IEnumerator IA() //En esta corrutina el enemigo espera 1 segundo, selecciona una skill random de las que posee y la aplica 
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

