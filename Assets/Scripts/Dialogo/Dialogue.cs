using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string name;

    [TextArea(3, 10)] //Elijo en el editor cuantas frases va a haber, el nombre y lo que digan las mismas
    public string[] sentences;
}
