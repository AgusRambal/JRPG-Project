using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatusPanel : MonoBehaviour
{
    public TextMeshProUGUI nameLabel;
    public TextMeshProUGUI levelLabel;

    public Slider healthSlider;
    public Image healthSliderBar;
    public TextMeshProUGUI healthLabel;

    public void SetStats(string name, Stats stats) //Hago aparecer en el panel el nombre, el nivel y la vida seteada en el script stats y del enemigo o el player
    {
        this.nameLabel.text = name;

        this.levelLabel.text = $"LVL {stats.level}";
        this.SetHealth(stats.health, stats.maxHealth);
    }

    public void SetHealth(float health, float maxHealth) //Setea la vida maxima y la vida
    {
        this.healthLabel.text = $"{Mathf.RoundToInt(health)} / {Mathf.RoundToInt(maxHealth)}";
        float percentage = health / maxHealth;

        this.healthSlider.value = percentage;

        //Cmabio el color de la barra de vida depende mi porcdentaje de vida
        if (percentage > 0.67f)
        {
            this.healthSliderBar.color = Color.green;
        }
        if (percentage < 0.66f)
        {
            this.healthSliderBar.color = Color.yellow;
        }
        if (percentage < 0.33f) 
        {
            this.healthSliderBar.color = Color.red;
        }
    }
}
