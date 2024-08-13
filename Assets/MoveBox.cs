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
            // Her sætter vi boksens hastighed den køre med, hen over skærmen.
            transform.position += Vector3.left * speed * Time.deltaTime; // Boksens hastighed, udregnes ud fra den speed vi har sat i Unity

            if(transform.position.x < LeftEdge)
            {
                Destroy(gameObject); // Når boksen har forladt skærmen's rækkevide, så ødelægger vi boksen.
            }
    }
}
