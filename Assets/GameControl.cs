using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading;

public class GameControl : MonoBehaviour
{
    public GameObject etLiv, toLiv, treLiv; // Vores game objekter, bedre kendt som de liv vi har i toppen
    
    // Update is called once per frame
    void Update()
    {
        if (Player.lives == 3) // Hvis player-manden har alle tre liv
        {
            etLiv.gameObject.SetActive(true); // S� skal det f�rste liv v�re synligt 
            toLiv.gameObject.SetActive(true); // S� skal det andet liv v�re synligt 
            treLiv.gameObject.SetActive(true); // S� skal det tredje liv v�re synligt 

            /*
                 Dette her:

                            etLiv.gameObject.SetActive(true);

                Betyder:

                Objektet: etLiv, som er et: gameObject, hvis synlighed: SetActive, s�tter vi til: true
                P� den m�de bliver etLiv synlig i spillet.
            */
        }
        if (Player.lives == 2) // Hvis player-manden kun har to liv
        {
            etLiv.gameObject.SetActive(false); // S� skal det f�rste liv ikke v�re synligt 
            toLiv.gameObject.SetActive(true); // S� skal det andet liv v�re synligt 
            treLiv.gameObject.SetActive(true); // S� skal det tredje liv v�re synligt 
        }
        if (Player.lives == 1) // Hvis player-manden kun har et liv tilbage
        {
            etLiv.gameObject.SetActive(false); // S� skal det f�rste liv ikke v�re synligt 
            toLiv.gameObject.SetActive(false); // S� skal det andet liv ikke v�re synligt 
            treLiv.gameObject.SetActive(true); // S� skal det tredje liv v�re synligt 
        }
        if (Player.lives == 0) // Hvis player-manden ingen liv har tilbage
        {
            etLiv.gameObject.SetActive(false); // S� skal det f�rste liv ikke v�re synligt 
            toLiv.gameObject.SetActive(false); // S� skal det andet liv ikke v�re synligt 
            treLiv.gameObject.SetActive(false); // S� skal det tredje liv  ikke v�re synligt 
            ResetTimeAndLife(); // Kalder metoden ResetTimeAndLife, som ligger i klassen her
        }
        if (TimeLeft.timeLeft <= 0) // Hvis tiden i spillet er g�et
        {
            ResetTimeAndLife(); // Kalder metoden ResetTimeAndLife, som ligger i klassen her
        }
    }
    public static void ResetTimeAndLife() // Metoden ResetTimeAndLife
    {
        Time.timeScale = 0; // F�rst s�tter vi tiden til 0, for at v�re sikker p� at den starter forfra.
        if (Player.lives < 3) // S� tjekker vi om player-manden har fuldt liv
        {
            for (int i = Player.lives; i < 3; i++) // Hvis han ikke det fuldt liv, s� s�tter vi liv ind, for hvert han mangler.
            {
                ComConnector.SendSignalToMotorR(); // Kalder metoden fra ComConnecter, som l�sner snoren
                Player.lives += 1; // Plusser player-mandens liv med 1
                Debug.Log(Player.lives); // Udskriver hans liv, s� vi kan holde �je med det
                Thread.Sleep(4000); // Stopper lige spillet lynhurtig, s� vi kan se motoren k�re stille og roligt ud. 
            }
        }
    }
}
