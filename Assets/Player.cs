using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Player : MonoBehaviour 
{
    private Rigidbody2D rb; // Vores player-mand har en krop der hedder Rigidbody, denne skal vi sætte, hvilket giver ham nogen egenskaber, såsom tyngdekraft. 
    public int jumpVector; // Farten vi hopper med. Dette tal sættes inde i Unity
    public static int lives = 3; // Player-mandens liv 

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Her sætter vi vores rb "fast" til vores player-mands krop
    }

    // Update is called once per frame
    private void Update()
    {
        ComConnector.ReceiveInputFromArduino(); // Kalder metoden som tjekker om der er input fra Arduino IDE, metoden er inde i ComConnector
        if (ComConnector.jumpInput == 2) // Hvis inputtet vi får fra Arduino IDE er 2
        {
            rb.velocity = new Vector2(0, jumpVector); // Så sætter vi player-mands krop til at hoppe. Ved at sætte hans nye position, til hvad end vores jumpVector er
            ComConnector.jumpInput = 0; // Så sætter så jumpInput til 0, for at vi ved vi har modtaget inputtet, og ikke gør præcis det samme igen
        }
        
        if (Input.GetKey("space")) //Gør at vi kan hoppe så højt vi vil, når vi trykker på space
        {
            rb.velocity = new Vector2(0, jumpVector); //Udregningen for et hop
        }
    }   

    private void OnTriggerEnter2D(Collider2D other) // Hvis vores player-mand rammer noget
    {
       Debug.Log("Hit box");
       if (other.gameObject.tag == "Scoring") // Hvis den boks han rammer har tagget: Scoring
        {            
           Debug.Log("Hit scoring");
           Destroy(other.gameObject); // Vi ødelægger boksen 
           if (lives < 3) // Hvis player-mand har under tre liv, så
           {
               lives += 1; // Plusser vi hans liv
               Debug.Log(lives); 
               Time.timeScale = 0; // Stopper spillet
               ComConnector.SendSignalToMotorR(); // Kalder den metode, som løsner motoren
               Thread.Sleep(3500); // Holder lige en lille pause
               Time.timeScale = 1; // Starter tiden igen
           }
       }

       if (other.gameObject.tag == "Obstacle") // Hvis den boks han rammer har tagget: Obstacle
        {
           Debug.Log("Hit obstacle");
           Destroy(other.gameObject); // Vi ødelægger boksen 
            if (lives <= 3) // Hvis player-mand har lig med eller under tre liv, så
            {
               lives -= 1; // Minusser vi hans liv
               Debug.Log(lives);
               Time.timeScale = 0; // Stopper spillet
               ComConnector.SendSignalToMotorL(); // Kalder den metode, som løsner motoren
               Thread.Sleep(3500); // Holder lige en lille pause
               Time.timeScale = 1; // Starter tiden igen
            }   
       }
    }
}
