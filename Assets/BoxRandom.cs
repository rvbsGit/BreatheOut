using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxRandom : MonoBehaviour
{
    public float maxTime; //Tiden der går før en ny kasse kommer. Dette tal sættes inde i Unity
    private float timer = 0; //Tælleren indtil næste kasse bliver lavet
    public float height; //Højden hvor i kasser kan blive lavet i. Dette tal sættes inde i Unity

    public List<GameObject> gameObjectsPool; //Listen af kasser, her sætter der inde i Unity objektet BadBox og GoodBox ind
    public GameObject baaad; // Et almindeligt dumt gameObjekt, så vi kun sender dårlige bokse ud når player-manden har fuldt liv

    public void gameObjectsBad()
    {
        Vector2 pos; // Gør det muligt for os at sætte bokses position
        pos = new Vector2(15, Random.Range(-height, height)); //Sætter højden for kassen
        Instantiate(baaad, pos, baaad.transform.rotation); //Oprettelse af boksen  
    }

    public void gameObjects()
    {
        int randomItem = 0; // Et eller andet random tal
        GameObject toRandom; // Lavet en lille fake gameObject
        Vector2 pos; // Dens position

        randomItem = Random.Range(0, gameObjectsPool.Count); //Tager et tal fra listen, her bliver det random tal sat ind i randomItem 
        toRandom = gameObjectsPool[randomItem]; //Indsætter tallet fra randomItem til et gameObject
        pos = new Vector2(15, Random.Range(-height, height)); //Sætter højden for boksen

        Instantiate(toRandom, pos, toRandom.transform.rotation); //Laver så boksen, ud fra højden, og det fake gameObject, som nu bliver til et "rigtigt" ud fra det random tal vi fandt.
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > maxTime) //Tjekker om tiden er gået over, hvor lang tid, der må gå før der må komme en ny kasse
        {
            if(Player.lives == 3) // Hvis player-mandens liv er lig med 3
            {
                Debug.Log("Solo baaaaad boxes :(");
                gameObjectsBad(); // Så kalder vi metoden, der kun laver dårlige og dumme bokse
                timer = 0; //Sætter tiden til nul, så vi ved hvornår vi skal lave en ny kasse
            }
            else // Hvis player-manden har alt andet end 3 liv,
            {
                Debug.Log("Random boxes!");
                gameObjects(); // Så kalder vi metoden, der laver alle mulige bokse
                timer = 0; //Sætter tiden til nul, så vi ved hvornår vi skal lave en nu kasse
            }
        }
        timer += Time.deltaTime; //Optæller tiden til ny kasse
    }
}

