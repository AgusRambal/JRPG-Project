using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusModSkill : Skill
{
    [Header("Status Mod Skill")]
    public string message;

    protected StatusMod mod;

    protected override void OnRun()
    {
        if (this.mod == null)
        {
            this.mod = this.GetComponent<StatusMod>();
        }

        this.messages.Enqueue(message.Replace("{receiver}", receiver.idName));

        receiver.statusMods.Add(mod);
    }
}