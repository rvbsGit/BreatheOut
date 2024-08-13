using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeLeft : MonoBehaviour
{
    Text text; // Gier os muligheden for at ændre tiden i spillet.
    public static float timeLeft = 40f; // Sætter tiden i spillet, så lige nu står den på 40, hvilket betuder at de spiller i 40 sekunder.

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>(); // Vi connecter text med objektet text i spillet, så vi kan ændre tiden.
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime; // Her skriver vi tiden tilbage, minus den tid der er gået skriver vi ind i variablen timeLeft
        if (timeLeft < 0) { // Hvis timeLeft er under 0
            timeLeft = 0; // Så sætter vi tiden til 0
        }
        text.text = "Tid tilbage: " + Mathf.Round(timeLeft);  // Udskriver hvad der står i timeLeft
    }
}
