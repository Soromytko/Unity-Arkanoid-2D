using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBlockMove : MonoBehaviour
{
    public float speedV;
    public float point;
    
    void Start()
    {
        //«адаетс€ начальна€ скорость. —лучайно выбираетс€ число от 1 до 6
        speedV = Random.Range(1, 6);

        System.Random rand = new System.Random();
        //¬ыбираетс€ направление движени€. ѕри скорости с отрицательным значением движетс€ влево, с положительным вправо.
        int[] a = new int[2] { -1, 1 };
        speedV = speedV * a[rand.Next(0, a.Length)];
    }

    
    void Update()
    {
        //Ѕлок движетс€ по оси х
        transform.Translate(speedV * Time.deltaTime, 0, 0);
        //ѕри достижении одного значений -5.8f или 5.8f блок мен€ет направление движени€ 
        if (transform.position.x > 5.8f || transform.position.x < -5.8f )
        {
            speedV = -speedV;

        }
        
        
    }
}
