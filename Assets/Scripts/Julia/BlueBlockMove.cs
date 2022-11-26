using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBlockMove : MonoBehaviour
{
    public float speedV;
    public float point;
    
    void Start()
    {
        //�������� ��������� ��������. �������� ���������� ����� �� 1 �� 6
        speedV = Random.Range(1, 6);

        System.Random rand = new System.Random();
        //���������� ����������� ��������. ��� �������� � ������������� ��������� �������� �����, � ������������� ������.
        int[] a = new int[2] { -1, 1 };
        speedV = speedV * a[rand.Next(0, a.Length)];
    }

    
    void Update()
    {
        //���� �������� �� ��� �
        transform.Translate(speedV * Time.deltaTime, 0, 0);
        //��� ���������� ������ �������� -5.8f ��� 5.8f ���� ������ ����������� �������� 
        if (transform.position.x > 5.8f || transform.position.x < -5.8f )
        {
            speedV = -speedV;

        }
        
        
    }
}
