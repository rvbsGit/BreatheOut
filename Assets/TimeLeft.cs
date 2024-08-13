using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeLeft : MonoBehaviour
{
    Text text; // Gier os muligheden for at �ndre tiden i spillet.
    public static float timeLeft = 40f; // S�tter tiden i spillet, s� lige nu st�r den p� 40, hvilket betuder at de spiller i 40 sekunder.

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>(); // Vi connecter text med objektet text i spillet, s� vi kan �ndre tiden.
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime; // Her skriver vi tiden tilbage, minus den tid der er g�et skriver vi ind i variablen timeLeft
        if (timeLeft < 0) { // Hvis timeLeft er under 0
            timeLeft = 0; // S� s�tter vi tiden til 0
        }
        text.text = "Tid tilbage: " + Mathf.Round(timeLeft);  // Udskriver hvad der st�r i timeLeft
    }
}
