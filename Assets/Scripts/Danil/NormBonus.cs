using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NormBonus : BonusBase
{
    void Start()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
        Text textComponent = transform.GetChild(0).GetChild(0).GetComponent<Text>();
        textComponent.text = "Norm";
        textComponent.color = Color.black;
    }

    protected override void BonusActivate()
    {
        var balls = FindObjectsOfType<BallScript>();

        foreach (var ball in balls)
            ball.SetNorm();
    }
}
