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
            etLiv.gameObject.SetActive(true); // Så skal det første liv være synligt 
            toLiv.gameObject.SetActive(true); // Så skal det andet liv være synligt 
            treLiv.gameObject.SetActive(true); // Så skal det tredje liv være synligt 

            /*
                 Dette her:

                            etLiv.gameObject.SetActive(true);

                Betyder:

                Objektet: etLiv, som er et: gameObject, hvis synlighed: SetActive, sætter vi til: true
                På den måde bliver etLiv synlig i spillet.
            */
        }
        if (Player.lives == 2) // Hvis player-manden kun har to liv
        {
            etLiv.gameObject.SetActive(false); // Så skal det første liv ikke være synligt 
            toLiv.gameObject.SetActive(true); // Så skal det andet liv være synligt 
            treLiv.gameObject.SetActive(true); // Så skal det tredje liv være synligt 
        }
        if (Player.lives == 1) // Hvis player-manden kun har et liv tilbage
        {
            etLiv.gameObject.SetActive(false); // Så skal det første liv ikke være synligt 
            toLiv.gameObject.SetActive(false); // Så skal det andet liv ikke være synligt 
            treLiv.gameObject.SetActive(true); // Så skal det tredje liv være synligt 
        }
        if (Player.lives == 0) // Hvis player-manden ingen liv har tilbage
        {
            etLiv.gameObject.SetActive(false); // Så skal det første liv ikke være synligt 
            toLiv.gameObject.SetActive(false); // Så skal det andet liv ikke være synligt 
            treLiv.gameObject.SetActive(false); // Så skal det tredje liv  ikke være synligt 
            ResetTimeAndLife(); // Kalder metoden ResetTimeAndLife, som ligger i klassen her
        }
        if (TimeLeft.timeLeft <= 0) // Hvis tiden i spillet er gået
        {
            ResetTimeAndLife(); // Kalder metoden ResetTimeAndLife, som ligger i klassen her
        }
    }
    public static void ResetTimeAndLife() // Metoden ResetTimeAndLife
    {
        Time.timeScale = 0; // Først sætter vi tiden til 0, for at være sikker på at den starter forfra.
        if (Player.lives < 3) // Så tjekker vi om player-manden har fuldt liv
        {
            for (int i = Player.lives; i < 3; i++) // Hvis han ikke det fuldt liv, så sætter vi liv ind, for hvert han mangler.
            {
                ComConnector.SendSignalToMotorR(); // Kalder metoden fra ComConnecter, som løsner snoren
                Player.lives += 1; // Plusser player-mandens liv med 1
                Debug.Log(Player.lives); // Udskriver hans liv, så vi kan holde øje med det
                Thread.Sleep(4000); // Stopper lige spillet lynhurtig, så vi kan se motoren køre stille og roligt ud. 
            }
        }
    }
}
