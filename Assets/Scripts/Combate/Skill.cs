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

    protected Queue<string> messages;

    /* private void Animate()
     {
         var go = Instantiate(this.effectPrfb, this.receiver.transform.position, Quaternion.identity);
         Destroy(go, this.animationDuration);
     }*/

    private void Awake() //Vacio el queue para poder poner los mensajes en el panel
    {
        this.messages = new Queue<string>();
    }

    public void Run() //Utilizo el self inflicted para poder usar la curacion
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

    public string GetNextMessage() //Resto de la queue el mensaje siguiente y chequeo si hay o no hay
    {
        if (this.messages.Count !=0)
        {
            return this.messages.Dequeue();
        }
        else
        {
            return null;
        }
    }
    protected abstract void OnRun();

}