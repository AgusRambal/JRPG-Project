using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HealthModType
{ 
    STAT_BASED, FIXED, PERCENTAGE
}

public class HealthModSkill : Skill
{
    [Header("HealthModSkill Mod")]
    public float amount;

    public HealthModType modType;

    [Range(0f, 6f)] public float critChance = 6; 

    protected override void OnRun()
    {
        float amount = this.GetModification();

        this.receiver.ModifyHealth(amount);

        float dice = Random.Range(0f, 5f);

        if (dice == critChance) //Aca podria poner diferentes danios
        {
            amount *= 2f;
            this.messages.Enqueue("Critical Hit!");
        }
    }

    public float GetModification()
    {
        switch (this.modType)
        {
            case HealthModType.STAT_BASED:

                Stats emitterStats = this.emitter.GetCurrentStats();
                Stats receiverStats = this.receiver.GetCurrentStats();

                float rawDamage = (((2 * emitterStats.level) / 5) + 2) * this.amount * (emitterStats.attack / receiverStats.deffense);

                return (rawDamage / 50) + 2;

            case HealthModType.FIXED:
                return this.amount;
            case HealthModType.PERCENTAGE:
                Stats rStats = this.receiver.GetCurrentStats();

                return rStats.maxHealth * this.amount;
        }

        throw new System.InvalidOperationException("HealthModSkill::GetDamage. Unreachable!");

    }
}