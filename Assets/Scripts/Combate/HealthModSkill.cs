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

    protected override void OnRun()
    {
        float amount = this.GetModification();

        this.receiver.ModifyHealth(amount);
    }

    public float GetModification()
    {
        switch (this.modType)
        {
            case HealthModType.STAT_BASED: //Resta el daño en base a mis estadisticas y un dado D20

                Stats emitterStats = this.emitter.GetCurrentStats();
                Stats receiverStats = this.receiver.GetCurrentStats();

                float rawDamage = - ((Random.Range(1f, 20f)*emitterStats.level)/this.amount) * (emitterStats.attack / receiverStats.deffense);

                return rawDamage;

            case HealthModType.FIXED: //Resta el daño puesto en el editor
                return this.amount;
            case HealthModType.PERCENTAGE: //utiliza un porcentaje para curar
                Stats rStats = this.receiver.GetCurrentStats();

                return rStats.maxHealth * this.amount;
        }

        throw new System.InvalidOperationException("HealthModSkill::GetDamage. Unreachable!");

    }
}
