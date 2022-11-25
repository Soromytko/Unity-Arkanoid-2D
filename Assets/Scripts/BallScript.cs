using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public Vector2 ballInitialForce;
    Rigidbody2D rb;
    GameObject playerObj;
    float deltaX;
    AudioSource audioSrc; 
    public AudioClip hitSound; 
    public AudioClip loseSound;
    public GameDataScript gameData;

    int currentDamage = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerObj = GameObject.FindGameObjectWithTag("Player");
        deltaX = transform.position.x;
        audioSrc = Camera.main.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (rb.isKinematic) 
            if (Input.GetButtonDown("Fire1")) { 
                rb.isKinematic = false; 
                rb.AddForce(ballInitialForce); 
            } 
            else { 
                var pos = transform.position;
                pos.x = playerObj.transform.position.x + deltaX;
                transform.position = pos; 
            }
        if (!rb.isKinematic && Input.GetKeyDown(KeyCode.J)) {
            var v = rb.velocity; 
            if (Random.Range(0, 2) == 0) v.Set(v.x - 0.1f, v.y + 0.1f);
            else v.Set(v.x + 0.1f, v.y - 0.1f);
            rb.velocity = v; 
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (gameData.sound) audioSrc.PlayOneShot(loseSound,5);
        Destroy(gameObject);
        playerObj.GetComponent<PlayerScript>().BallDestroyed();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameData.sound) audioSrc.PlayOneShot(hitSound, 5);

        if(collision.transform.TryGetComponent(out BlockScript result))
            result.TakeDamage(currentDamage);
    }


    //Danil=====



    public void SetNorm()
    {
        currentDamage = 1;
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    public void SetFire()
    {
        currentDamage = 4; //текущий урон шара
        GetComponent<SpriteRenderer>().color = Color.red; //меняем цвет
    }

    public void SetMetal()
    {
        currentDamage = 40;
        GetComponent<SpriteRenderer>().color = Color.gray;
    }

}
