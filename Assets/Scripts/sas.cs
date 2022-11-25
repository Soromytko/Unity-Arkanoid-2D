using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sas : BonusBase
{
    void Start()
    {
        GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f);
        Text textComponent = transform.GetChild(0).GetChild(0).GetComponent<Text>();
        textComponent.text = "+300";
        textComponent.color = new Color(255f,255f,255f);
    }

    protected override void BonusActivate()
    {
        GameObject.FindGameObjectWithTag("Player").
            GetComponent<PlayerScript>().gameData.points += 300;
    }
}
