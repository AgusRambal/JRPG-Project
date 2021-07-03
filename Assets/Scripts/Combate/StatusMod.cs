using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatusModType
{ 
    ATTACK_MOD,
    DEFENSE_MOD
}

public class StatusMod : MonoBehaviour
{
    public StatusModType type;
    public float amount;

    public Stats Apply(Stats stats)
    {
        Stats modedStats = stats.Clone();

        switch (this.type)
        {
            case StatusModType.ATTACK_MOD:
                modedStats.attack += this.amount;
                break;
            case StatusModType.DEFENSE_MOD:
                modedStats.deffense += this.amount;
                break;
        }
        return modedStats;
    }
}
