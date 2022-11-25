using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class BonusBase : MonoBehaviour
{
    void Start()
    {
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 0f);
        Text textComponent = transform.GetChild(0).GetChild(0).GetComponent<Text>();
        textComponent.text = "+100";
        textComponent.color = new Color(0f, 0f, 0f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Bottom Wall")
        {
            Destroy(gameObject);
        }
        else
        {
            BonusActivate();
            Destroy(gameObject);
        }
    }

    protected virtual void BonusActivate()
    {
        GameObject.FindGameObjectWithTag("Player").
            GetComponent<PlayerScript>().gameData.points += 100;
    }

}
