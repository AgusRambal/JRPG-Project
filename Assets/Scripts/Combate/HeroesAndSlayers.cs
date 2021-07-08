using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HeroesAndSlayers : MonoBehaviour
{
    public string idName;
    public StatusPanel statusPanel;

    public CombatManager combatManager;

    public List<StatusMod> statusMods;

    protected Stats stats;

    protected Skill[] skills;

    protected virtual void Start()
    {
        this.statusPanel.SetStats(this.idName, this.stats);
        this.skills = this.GetComponentsInChildren<Skill>();


        this.statusMods = new List<StatusMod>();
    }

    public void ModifyHealth(float amount) //Seteo la vida en el panel y le pongo un maximo y un minimo
    {
        this.stats.health = Mathf.Clamp(this.stats.health + amount, 0f, this.stats.maxHealth);

        this.stats.health = Mathf.Round(this.stats.health);
        this.statusPanel.SetHealth(this.stats.health, this.stats.maxHealth);
    }

    public Stats GetCurrentStats() //Reemplazo las stats por las stats modificadas cuando uso weak o rage
    {
        Stats modedStats = this.stats;

        foreach (var mod in this.statusMods)
        {
            modedStats = mod.Apply(modedStats);
        }

        return modedStats;
    }

    public abstract void InitTurn();
}
