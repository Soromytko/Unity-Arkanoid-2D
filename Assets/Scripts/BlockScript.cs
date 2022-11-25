using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockScript : MonoBehaviour
{
    public GameObject textObject;
    Text textComponent;
    public int hitsToDestroy;
    public int points;
    PlayerScript playerScript;

    void Start()
    {
        if (textObject != null)
        {
            textComponent = textObject.GetComponent<Text>(); 
            textComponent.text = hitsToDestroy.ToString(); 
        }
        playerScript = GameObject.FindGameObjectWithTag("Player")
            .GetComponent<PlayerScript>();
    }

    public void TakeDamage(int damage)
    {
        hitsToDestroy -= damage;
        if (hitsToDestroy <= 0)
        {
            Destroy(gameObject);
            playerScript.BlockDestroyed(points);
            if (name.Contains("Green Block")) // a1
                playerScript.BonusArrive(transform.position.x,
                    transform.position.y);
        }
        else if (textComponent != null)
            textComponent.text = hitsToDestroy.ToString();
    }
}
