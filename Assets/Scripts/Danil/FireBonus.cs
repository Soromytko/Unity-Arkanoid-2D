using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireBonus : BonusBase
{
    void Start()
    {
        GetComponent<SpriteRenderer>().color = Color.red; //цвет фона
        Text textComponent = transform.GetChild(0).GetChild(0).GetComponent<Text>();
        textComponent.text = "Fire";
        textComponent.color = Color.black; //цвет текста
    }

    protected override void BonusActivate()
    {
        var balls = FindObjectsOfType<BallScript>();

        foreach (var ball in balls)
            ball.SetFire();
    }
}
