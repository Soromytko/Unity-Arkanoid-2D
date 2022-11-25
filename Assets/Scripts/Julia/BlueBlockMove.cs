using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBlockMove : MonoBehaviour
{
    public float speedV;
    public float point;
    
    void Start()
    {
        point = transform.position.x;
        if (point > -1.2f & point < 0)
            transform.position = new Vector3(-1.5f, 0, 0);
        else if (point < 1.2f & point > 0)
            transform.position = new Vector3(1.5f, 0, 0);
        else if (point <-4f)
            transform.position = new Vector3(Random.Range(-4,-2), 0, 0);
        else if (point > 4f)
            transform.position = new Vector3(Random.Range(2,4), 0, 0);
        point = transform.position.x;

        speedV = Random.Range(1, 6);

        System.Random rand = new System.Random();
        int[] a = new int[2] { -1, 1 };
        speedV = speedV * a[rand.Next(0, a.Length)];
    }

    
    void Update()
    {
        
        transform.Translate(speedV * Time.deltaTime, 0, 0);
        if (speedV > 3 || speedV < -3)
        {
            if (transform.position.x > 5.5f || transform.position.x < -5.5f)
            {
                speedV = -speedV;
            }
        }
        else
        {
            if (point < 0 & point > -5.5)
                if (transform.position.x > 0 || transform.position.x < -5.5f)
                {
                    speedV = -speedV;
                }
            if (point > 0 & point < 5.5f)
                if (transform.position.x > 5.5f || transform.position.x < 0)
                {
                    speedV = -speedV;
                }
        }
        


    }
}
