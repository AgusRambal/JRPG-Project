using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerSkillPanel : MonoBehaviour
{
    public GameObject[] skillButtons;
    public TextMeshProUGUI[] skillButtonLabels;

    private void Awake() //Oculto el panel y los botones
    {
        this.Hide();

        foreach (var btn in this.skillButtons)
        {
            btn.SetActive(false);
        }
    }

    public void ConfigureButtons(int index, string skillName) //Pongo el nombre de las skills en los paneles
    {
        this.skillButtons[index].SetActive(true);
        this.skillButtonLabels[index].text = skillName;
    }

    public void Show() //Muestro las skills
    {
        this.gameObject.SetActive(true);
    }

    public void Hide()
    {
        this.gameObject.SetActive(false);
    }
}
