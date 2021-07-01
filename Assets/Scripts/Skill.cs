using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : MonoBehaviour
{
    [Header("Base Skill")]
    public string skillName;
    //public float animationDuration;

    public bool selfInflicted;

    //public GameObject effectPrfb;

    protected HeroesAndSlayers emitter;
    protected HeroesAndSlayers receiver;

   /* private void Animate()
    {
        var go = Instantiate(this.effectPrfb, this.receiver.transform.position, Quaternion.identity);
        Destroy(go, this.animationDuration);
    }*/

    public void Run()
    {
        if (this.selfInflicted)
        {
            this.receiver = this.emitter;
        }

        //this.Animate();

        this.OnRun();
    }

    public void SetEmitterAndReceiver(HeroesAndSlayers _emitter, HeroesAndSlayers _receiver)
    {
        this.emitter = _emitter;
        this.receiver = _receiver;
    }
    protected abstract void OnRun();

}
