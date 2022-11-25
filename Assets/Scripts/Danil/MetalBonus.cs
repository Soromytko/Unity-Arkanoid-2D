using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MetalBonus : BonusBase
{
    void Start()
    {
        GetComponent<SpriteRenderer>().color = Color.gray;
        Text textComponent = transform.GetChild(0).GetChild(0).GetComponent<Text>();
        textComponent.text = "Metal";
        textComponent.color = Color.black;
    }

    protected override void BonusActivate()
    {
        var balls = FindObjectsOfType<BallScript>();

        foreach (var ball in balls)
            ball.SetMetal();
    }



}
