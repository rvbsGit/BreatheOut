using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBox : MonoBehaviour
{
    public float speed; 
    private float LeftEdge;

    void Start()
    {
        //Dette skal Robert forklare.
        LeftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f; 
    }

    void Update()
    {
            // Her s�tter vi boksens hastighed den k�re med, hen over sk�rmen.
            transform.position += Vector3.left * speed * Time.deltaTime; // Boksens hastighed, udregnes ud fra den speed vi har sat i Unity

            if(transform.position.x < LeftEdge)
            {
                Destroy(gameObject); // N�r boksen har forladt sk�rmen's r�kkevide, s� �del�gger vi boksen.
            }
    }
}
