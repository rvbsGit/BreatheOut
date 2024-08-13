using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.Threading;

// Robert burde nok forklare hvad der sker i denne klasse, da han har lavet den. Men nu giver jeg det et fors�g.

public class ComConnector : MonoBehaviour
{
    public static SerialPort sp = new SerialPort("COM5", 9600); // Her �bner vi porten, og siger hvor ofte porten skal tjekkes. Disse tal skal stemme overens med hvad der st�r i Arduino IDE
    public static int jumpInput; // Dette er en int, som vi s�tter i klassen og bliver l�st i Player klassen, s� player-manden hopper

    void Start() // Bliver kaldt i starten af spillet og ellers aldrig igen
    {
        OpenConnection(); // Her kalder vi metoden som �bner porten
    }

    public void OpenConnection()
    {
        if (sp !=null) // Hvis porten er forskellige fra null
        {
            if(sp.IsOpen) // Hvis porten er �ben
            {
                sp.Close(); // Luk porten
                print("Closing port");
            }
            else
            {
                sp.Open(); // Hvis porten ikke er �ben, s� �ben porten
                sp.ReadTimeout = 16;
                print("Port opened!");
            }
        }
        else // Hvis porten er null, s� lukker vi porten her
        {
            if(sp.IsOpen)
            {
                sp.Close();
            }
        }
    }

    public static void ReceiveInputFromArduino() // Metoden som l�ser om der er noget input fra porten, denne metode bliver kalde i Player klassen
    {
        try
        {
            if(sp.ReadByte()==1) // Hvis det man l�ser fra porten er lig med 1 
            {
                jumpInput = 2; // S� s�tter vi jumpInput til 2
            }
        }
        catch(System.Exception){} // Hvis ikke man fanger noget, s� laver vi en Exception
    }

    public static void SendSignalToMotorL() // Metoden som f�r motoren til at stramme, denne metode kalder vi i Player klassen
    {
        sp.Write("3"); // Skriv 3 til Arduino IDE
        Debug.Log("Motor strammer");
    }

    public static void SendSignalToMotorR() // Metoden som f�r motoren til at l�se sig, denne metode kalder vi i Player klassen samt GameControl klassen
    {
        sp.Write("4"); // Skriv 4 til  Arduino IDE
        Debug.Log("Motor l�sner");
    }
}
