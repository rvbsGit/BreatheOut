using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.Threading;

// Robert burde nok forklare hvad der sker i denne klasse, da han har lavet den. Men nu giver jeg det et forsøg.

public class ComConnector : MonoBehaviour
{
    public static SerialPort sp = new SerialPort("COM5", 9600); // Her åbner vi porten, og siger hvor ofte porten skal tjekkes. Disse tal skal stemme overens med hvad der står i Arduino IDE
    public static int jumpInput; // Dette er en int, som vi sætter i klassen og bliver læst i Player klassen, så player-manden hopper

    void Start() // Bliver kaldt i starten af spillet og ellers aldrig igen
    {
        OpenConnection(); // Her kalder vi metoden som åbner porten
    }

    public void OpenConnection()
    {
        if (sp !=null) // Hvis porten er forskellige fra null
        {
            if(sp.IsOpen) // Hvis porten er åben
            {
                sp.Close(); // Luk porten
                print("Closing port");
            }
            else
            {
                sp.Open(); // Hvis porten ikke er åben, så åben porten
                sp.ReadTimeout = 16;
                print("Port opened!");
            }
        }
        else // Hvis porten er null, så lukker vi porten her
        {
            if(sp.IsOpen)
            {
                sp.Close();
            }
        }
    }

    public static void ReceiveInputFromArduino() // Metoden som læser om der er noget input fra porten, denne metode bliver kalde i Player klassen
    {
        try
        {
            if(sp.ReadByte()==1) // Hvis det man læser fra porten er lig med 1 
            {
                jumpInput = 2; // Så sætter vi jumpInput til 2
            }
        }
        catch(System.Exception){} // Hvis ikke man fanger noget, så laver vi en Exception
    }

    public static void SendSignalToMotorL() // Metoden som får motoren til at stramme, denne metode kalder vi i Player klassen
    {
        sp.Write("3"); // Skriv 3 til Arduino IDE
        Debug.Log("Motor strammer");
    }

    public static void SendSignalToMotorR() // Metoden som får motoren til at løse sig, denne metode kalder vi i Player klassen samt GameControl klassen
    {
        sp.Write("4"); // Skriv 4 til  Arduino IDE
        Debug.Log("Motor løsner");
    }
}
